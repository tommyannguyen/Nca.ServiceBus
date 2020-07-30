using System;

namespace Nca.ServiceBus.Models
{
    public interface IMessage
    {
        Guid Id { get; }
        DateTime CreationDate { get; }
    }

}
