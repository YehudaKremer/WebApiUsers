using IPlan.Common.Extensions.DependencyInjection;
using MassTransit;
using UsersService.Consumers;

namespace UsersService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();

                    services.AddMessageBroker(option =>
                    {
                        option.RabbitMqConfigure = (context, rabbitConfig) =>
                        {
                            rabbitConfig.Host("localhost", "usersExample", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });
                        };
                    });
                })
                .Build();

            host.Run();
        }
    }
}