using Nca.ServiceBus.Models;
using System.Threading.Tasks;

namespace Nca.ServiceBus
{
    public interface IEventBus
    {
        Task PublishAsync(IMessage @event);

        void Subscribe<T, TH>()
            where T : IMessage
            where TH : IIntegrationMessageHandler<T>;

        void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIntegrationEventHandler;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationMessageHandler<T>
            where T : IMessage;
    }
}
