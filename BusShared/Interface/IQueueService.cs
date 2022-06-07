using System.Threading.Tasks;

namespace BusShared.Interface
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T messageBus, string queueName);
    }
}
