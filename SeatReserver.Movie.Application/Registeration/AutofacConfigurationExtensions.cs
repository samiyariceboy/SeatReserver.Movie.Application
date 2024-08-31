using Autofac;
using MediaService.Services.Services.OpenApiServices.AwsS3Service;
using SeatReserver.Movie.Application.Filters;
using SeatReserver.Movie.Domain.Common.InterfaceDependency;
using SeatReserver.Movie.Domain.Entities;
using SeatReserver.Movie.Infrastructure.DbContexts.Sql.SqlServer;
using System.Reflection;

namespace VoipService.Api.Configuration
{
    public static class AutofacConfigurationExtensions
    {
        #region NewConfiguration
        public class ServiceModules : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);

                #region Register AwsS3 Accessor
                builder.RegisterAwsS3Accessor();
                #endregion

                #region Auto Assembly Registeration services with autofac and interface class
                Assembly ApiAssembly = typeof(ApiResultFilterAttribute).Assembly;
                Assembly EntitiesAssembly = typeof(IEntity).Assembly;
                Assembly DataAssembly = typeof(ApplicationDbContext).Assembly;

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<IScopedDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<ITransientDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<ISingletonDependency>()
                    .AsImplementedInterfaces()
                    .SingleInstance();
                #endregion
                #endregion
            }
        }

        #region Accessors

        private static void RegisterAwsS3Accessor(this ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var accessKey = config.GetValue<string>("SFTPSetting:Host") ?? "";
                var secretKey = config.GetValue<string>("SFTPSetting:UserName") ?? "";
                var endpointUrl = config.GetValue<string>("SFTPSetting:Password") ?? "";

                return new AwsS3Service(accessKey, secretKey, endpointUrl);
            }).As<IAwsS3Service>();
        }
        #endregion
    }
}
