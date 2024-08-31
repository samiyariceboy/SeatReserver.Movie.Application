﻿using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Ardalis.Specification.EntityFrameworkCore;
using SeatReserver.Movie.Domain.Entities;
using SeatReserver.Movie.Infrastructure.DbContexts.Sql.SqlServer;
using SeatReserver.Movie.Domain.DataAccess.Repositories;

namespace SeatReserver.Movie.Infrastructure.DataAccess.Repositories
{
    public abstract class BaseRepository<TContext, TEntity> : RepositoryBase<TEntity>
        where TContext : DbContext
        where TEntity : class, IEntity
    {
        protected readonly TContext _dbContext;
        public BaseRepository(TContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.AddRangeAsync(entities, cancellationToken);
        }

        public override Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.AnyAsync(specification, cancellationToken);
        }

        public override Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return base.AnyAsync(cancellationToken);
        }

        public override IAsyncEnumerable<TEntity> AsAsyncEnumerable(ISpecification<TEntity> specification)
        {
            return base.AsAsyncEnumerable(specification);
        }

        public override Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.CountAsync(specification, cancellationToken);
        }

        public override Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return base.CountAsync(cancellationToken);
        }

        public override Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(entity, cancellationToken);
        }

        public override Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.DeleteRangeAsync(entities, cancellationToken);
        }

        public override Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(specification, cancellationToken);
        }

        public override Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default) where TResult : default
        {
            return base.FirstOrDefaultAsync(specification, cancellationToken);
        }

        public override Task<TEntity> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        public override Task<TEntity> GetBySpecAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.GetBySpecAsync(specification, cancellationToken);
        }

        public override Task<TResult?> GetBySpecAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default) where TResult : default
        {
            return base.GetBySpecAsync(specification, cancellationToken);
        }

        public override Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default)
        {
            return base.ListAsync(cancellationToken);
        }

        public override Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.ListAsync(specification, cancellationToken);
        }

        public override Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return base.ListAsync(specification, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<TEntity> SingleOrDefaultAsync(ISingleResultSpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.SingleOrDefaultAsync(specification, cancellationToken);
        }

        public override Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default) where TResult : default
        {
            return base.SingleOrDefaultAsync(specification, cancellationToken);
        }

        public override Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(entity, cancellationToken);
        }

        public override Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.UpdateRangeAsync(entities, cancellationToken);
        }

        protected override IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification, bool evaluateCriteriaOnly = false)
        {
            return base.ApplySpecification(specification, evaluateCriteriaOnly);
        }

        protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<TEntity, TResult> specification)
        {
            return base.ApplySpecification(specification);
        }
    }

    public class BaseRepository<TEntity> : BaseRepository<ApplicationDbContext, TEntity>,
        IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
        public BaseRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.AddRangeAsync(entities, cancellationToken);
        }

        public override Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.AnyAsync(specification, cancellationToken);
        }

        public override Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return base.AnyAsync(cancellationToken);
        }

        public override IAsyncEnumerable<TEntity> AsAsyncEnumerable(ISpecification<TEntity> specification)
        {
            return base.AsAsyncEnumerable(specification);
        }

        public override Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.CountAsync(specification, cancellationToken);
        }

        public override Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return base.CountAsync(cancellationToken);
        }

        public override Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(entity, cancellationToken);
        }

        public override Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.DeleteRangeAsync(entities, cancellationToken);
        }

        public override Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(specification, cancellationToken);
        }

        public override Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default) where TResult : default
        {
            return base.FirstOrDefaultAsync(specification, cancellationToken);
        }

        public override Task<TEntity> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        public override Task<TEntity> GetBySpecAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.GetBySpecAsync(specification, cancellationToken);
        }

        public override Task<TResult?> GetBySpecAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default) where TResult : default
        {
            return base.GetBySpecAsync(specification, cancellationToken);
        }

        public override Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default)
        {
            return base.ListAsync(cancellationToken);
        }

        public override Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.ListAsync(specification, cancellationToken);
        }

        public override Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return base.ListAsync(specification, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<TEntity> SingleOrDefaultAsync(ISingleResultSpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return base.SingleOrDefaultAsync(specification, cancellationToken);
        }

        public override Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default) where TResult : default
        {
            return base.SingleOrDefaultAsync(specification, cancellationToken);
        }

        public override Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(entity, cancellationToken);
        }

        public override Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return base.UpdateRangeAsync(entities, cancellationToken);
        }

        protected override IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification, bool evaluateCriteriaOnly = false)
        {
            return base.ApplySpecification(specification, evaluateCriteriaOnly);
        }

        protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<TEntity, TResult> specification)
        {
            return base.ApplySpecification(specification);
        }
    }

}
