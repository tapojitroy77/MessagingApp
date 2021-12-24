using ChatApplication.Entity;

namespace ChatApplication.SignalR
{
    public interface IHubMessageInvoke
    {
        List<Channel> GetChannels();
        List<Message> GetChannelMessages(string ChannelId);
    }
}
