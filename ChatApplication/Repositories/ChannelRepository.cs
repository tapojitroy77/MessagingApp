using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private static List<Channel> channels = new List<Channel>();

        public Channel CreateChannel(string ChannelName)
        {
            var channelId = Guid.NewGuid().ToString();
            var channel = new Channel { ChannelId = channelId, ChannelName = ChannelName };
            channels.Add(channel);
            return channel;
        }
        public List<Channel> GetAllChannels()
        {
            return channels;
        }

        public Channel GetChannelById(string ChannelId)
        {
            return channels.FirstOrDefault(channel => channel.ChannelId == ChannelId);
        }

        public bool DeleteChannel(string ChannelId)
        {
            if (channels.Exists(channel => channel.ChannelId == ChannelId))
            {
                channels.RemoveAll(channel => channel.ChannelId == ChannelId);
                return true;
            }

            return false;
        }
    }
}
