using System.Threading.Tasks;

namespace Nca.ServiceBus.Models
{
    public interface IDynamicIntegrationEventHandler
    {
        Task HandleAsync(dynamic eventData);
    }

}
