using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public interface IMessageRepository
    {
        public List<Message> GetMessagesByChannel(string ChannelId);
        public Message CreateMessage(string MessageText, string UserEmail, string ChannelId);
        public bool DeleteMessage(string MessageId);
    }
}
