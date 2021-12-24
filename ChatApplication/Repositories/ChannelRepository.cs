using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private static List<Channel> channels = new List<Channel>();

        public Channel CreateChannel(string Name)
        {
            var Id = Guid.NewGuid().ToString();
            var channel = new Channel { ChannelId = Id, Name = Name };
            channels.Add(channel);
            return channel;
        }
        public List<Channel> GetAllChannels()
        {
            return channels;
        }

        public Channel GetChannelById(string Id)
        {
            return channels.FirstOrDefault(channel => channel.ChannelId == Id);
        }

        public bool DeleteChannel(string Id)
        {
            if (channels.Exists(channel => channel.ChannelId == Id))
            {
                channels.RemoveAll(channel => channel.ChannelId == Id);
                return true;
            }

            return false;
        }
    }
}
