using Microsoft.EntityFrameworkCore;
using EFCoreSecondLevelCacheInterceptor;
using SeatReserver.Movie.Infrastructure.DbContexts.Sql.SqlServer;


namespace SeatReserver.Movie.Application.Registeration
{
    public static class RegisterDbContextConfiguration
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration config)
        {
            const string RedisProvider = "Redis01";
            services.AddEFSecondLevelCache(options =>
            {
                options.UseMemoryCacheProvider();

                //options.UseEasyCachingCoreProvider(RedisProvider, isHybridCache: false);
            });

            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(config.GetConnectionString("SqlServer"))
                    .AddInterceptors(serviceProvider
                    .GetRequiredService<SecondLevelCacheInterceptor>());

            }, ServiceLifetime.Scoped);

            //services.AddEasyCaching(option =>
            //{
            //    option.UseRedis(config =>
            //    {
            //        config.DBConfig.AllowAdmin = true;
            //        config.DBConfig.SyncTimeout = 10000;
            //        config.DBConfig.AsyncTimeout = 10000;
            //        config.DBConfig.Endpoints.Add(new EasyCaching.Core.Configurations.ServerEndPoint("127.0.0.1", 6379));
            //        config.EnableLogging = true;
            //        config.SerializerName = "Pack";
            //        config.DBConfig.ConnectionTimeout = 10000;
            //    }, RedisProvider);
            //});
        }
    }
}
