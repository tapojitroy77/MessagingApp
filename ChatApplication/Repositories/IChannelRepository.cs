using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public interface IChannelRepository
    {
        public Channel CreateChannel(string Name);
        public List<Channel> GetAllChannels();
        public bool DeleteChannel(string Id);
        public Channel GetChannelById(string Id);
    }
}
