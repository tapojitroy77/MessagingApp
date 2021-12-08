using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public interface IChannelRepository
    {
        public Channel CreateChannel(string ChannelName);
        public List<Channel> GetAllChannels();
        public bool DeleteChannel(string ChannelId);
        public Channel GetChannelById(string ChannelId);
    }
}
