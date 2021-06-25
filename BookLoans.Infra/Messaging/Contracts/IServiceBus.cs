using System.Threading.Tasks;

namespace BookLoans.Infra.Messaging.Contracts
{
    public interface IServiceBus
    {
        Task Publish(EventMessage message);
    }
}