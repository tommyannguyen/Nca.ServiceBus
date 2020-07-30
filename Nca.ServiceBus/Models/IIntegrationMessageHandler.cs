using System.Threading.Tasks;

namespace Nca.ServiceBus.Models
{
    public interface IIntegrationMessageHandler { }
    public interface IIntegrationMessageHandler<in TIntegrationEvent> : IIntegrationMessageHandler where TIntegrationEvent : IMessage
    {
        Task HandleAsync(TIntegrationEvent @event);
    }

}
