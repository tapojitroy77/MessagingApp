using ChatApplication.Entity;

namespace ChatApplication.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private static List<Message> messages = new List<Message>();
        private IChannelRepository channelRepository;
        private IUserRepository userRepository;

        public MessageRepository(IChannelRepository channelRepository, IUserRepository userRepository)
        {
            this.channelRepository = channelRepository;
            this.userRepository = userRepository;
        }
        public List<Message> GetMessagesByChannel(string ChannelId)
        {
            return messages.Where(message => message.Channel.ChannelId == ChannelId).ToList();
        }
        public Message CreateMessage(string MessageText, string UserEmail, string ChannelId)
        {
            var messageId = Guid.NewGuid().ToString();
            var message = new Message {
                MessageId = messageId,
                MessageText = MessageText,
                Channel =  this.channelRepository.GetChannelById(ChannelId),
                User = this.userRepository.GetUser(UserEmail)
            };
            messages.Add(message);
            return message;
        }
        public bool DeleteMessage(string MessageId)
        {
            if (messages.Exists(message => message.MessageId == MessageId))
            {
                messages.RemoveAll(message => message.MessageId == MessageId);
                return true;
            }

            return false;
        }
    }
}
