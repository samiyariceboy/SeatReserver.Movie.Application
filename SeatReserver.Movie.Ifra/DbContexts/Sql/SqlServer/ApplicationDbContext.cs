﻿using MediatR;
using SeatReserver.Movie.Domain.Entities;
using System.Reflection;
using SeatReserver.Movie.Domain.Common;
using SeatReserver.Movie.Infrastructure.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using SeatReserver.Movie.Domain.Common.Utilities;
using MassTransit;
using SeatReserver.Movie.Domain.Events.MovieEvents;

namespace SeatReserver.Movie.Infrastructure.DbContexts.Sql.SqlServer
{
    public class ApplicationDbContext: DbContext
    {
        private readonly IMediator _internalBus;
        private readonly IBus _externalBus;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator internalBus, IBus externalBus)
        : base(options)
        {
            _internalBus = internalBus;
            _externalBus=externalBus;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly entityAssembly = typeof(IEntity).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                conf => conf.IsClass && !conf.IsAbstract && conf.IsPublic);

            modelBuilder.RegisterAllEntities<IEntity>(entityAssembly);

            modelBuilder.RegisterEntityTypeConfiguration(entityAssembly);

            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        #region /// <summary>
        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _cleanString();
                int affectedRows = await base.SaveChangesAsync(cancellationToken);
                if (affectedRows > 0)
                {
                    await PublishEventsAsync(cancellationToken);
                }

                return affectedRows;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// هر چیزی که قراره آپدیت و یا ادد بشه رو، قبلش ی و ک عربی و فارسی و اعداد انگلیسی فارسیشون رو درست میکنه 
        /// </summary>
        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }
        #endregion

        #region Event Handeling

        private async Task PublishEventsAsync(CancellationToken cancellationToken)
        {
            //out box pattern
            //only aggregate root can raise event

            
            var aggregateRoots =
                    ChangeTracker.Entries()
                    .Where(current => current.Entity is IAggregateRoot)
                    .Select(current => current.Entity as IAggregateRoot)
                    .Where(c => c.DomainEvents.Any())
                    .ToList();

            foreach (var aggregateRoot in aggregateRoots)
                {
                foreach (var domainEvent in aggregateRoot.DomainEvents)
                    if (domainEvent.EventLocation == Domain.Events.DomainEvents.EventLocation.Internal)
                    {
                        await _internalBus.Publish(domainEvent, cancellationToken);
                    }
                    else if(domainEvent.EventLocation == Domain.Events.DomainEvents.EventLocation.External)
                    {
                        //convert domain event to type class with reflection
                        await _externalBus.Publish(domainEvent as MovieInfoUpdatedEvent, cancellationToken);
                    }
                aggregateRoot.ClearDomainEvents();
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
