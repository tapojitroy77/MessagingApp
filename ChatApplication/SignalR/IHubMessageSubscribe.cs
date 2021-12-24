using ChatApplication.Entity;

namespace ChatApplication.SignalR
{
    public interface IHubMessageSubscribe
    {
        Task SubscribeToMessageChannel(string channelId);
        Task messageAdded(Message message);
        Task messageDeleted(Message message);
        Task channelDeleted();
    }
}
