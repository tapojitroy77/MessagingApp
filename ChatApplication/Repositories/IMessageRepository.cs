using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public interface IMessageRepository
    {
        public List<Message> GetMessagesByChannel(string Id);
        public Message GetMessagesByMessageId(string MessageId);
        public Message CreateMessage(string MessageText, string ChannelId, string Id);
        public bool DeleteMessage(string MessageId);
    }
}
