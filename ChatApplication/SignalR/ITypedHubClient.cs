using ChatApplication.Entity;

namespace ChatApplication.SignalR
{
    public interface ITypedHubClient
    {
        Task BroadCastChannel(Channel Channel);
        Task BroadCastMessage(Message Message);
    }
}
