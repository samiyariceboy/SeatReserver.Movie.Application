
using MassTransit;
using SeatReserver.Movie.Application.Services.ApplicationServices.MovieApplicationServices.Consumers;

namespace SeatReserver.Movie.Application.Registeration
{
    public static class RegisterMasteransitConfiguration
    {
        public static void RegisterMasteransit(this IServiceCollection services, IConfiguration config)
        {
            var host = config.GetSection("MassTransitRabbitMqSettings:HostName").Value.ToString() ?? "";
            var port = config.GetSection("MassTransitRabbitMqSettings:Port").Value.ToString() ?? "";
            var userName = config.GetSection("MassTransitRabbitMqSettings:UserName").Value.ToString() ?? "";
            var password = config.GetSection("MassTransitRabbitMqSettings:Password").Value.ToString() ?? "";
            var virtualHost = config.GetSection("MassTransitRabbitMqSettings:VirtualHost").Value.ToString() ?? "";
            var transactionQueueName = config.GetSection("MassTransitRabbitMqSettings:TransactionQueueName").Value.ToString() ?? "";

            services.AddMassTransit(x =>
            {
                x.AddConsumer<MoviePosterImageShoudBeSentOnObjectStorageEventHandler>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(host, Convert.ToUInt16(port), virtualHost, h =>
                    {
                        h.Username(userName);
                        h.Password(password);
                    });

                    cfg.ReceiveEndpoint(transactionQueueName, c =>
                    {
                        c.ConfigureConsumer<MoviePosterImageShoudBeSentOnObjectStorageEventHandler>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();

        }
    }
}
