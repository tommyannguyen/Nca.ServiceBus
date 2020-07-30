using Microsoft.Extensions.DependencyInjection;

namespace Nca.ServiceBus.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtension {
        public static IServiceCollection AddServiceBus(this IServiceCollection services)
        {
            return services;
        }
    }
}
