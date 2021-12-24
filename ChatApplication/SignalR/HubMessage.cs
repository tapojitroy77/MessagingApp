using ChatApplication.Entity;
using ChatApplication.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.SignalR
{
    public class HubMessage : Hub<IHubMessageSubscribe>, IHubMessageInvoke
    {
        private IMessageRepository messageRepository;
        private IChannelRepository channelRepository;

        public HubMessage(IMessageRepository messageRepository, IChannelRepository channelRepository)
        {
            this.messageRepository = messageRepository;
            this.channelRepository = channelRepository;
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "MessageHub");
            await base.OnConnectedAsync();
        }

        public List<Channel> GetChannels()
        {
            return this.channelRepository.GetAllChannels();
        }

        public List<Message> GetChannelMessages(string ChannelId)
        {
            return this.messageRepository.GetMessagesByChannel(ChannelId);
        }
        public async Task SubscribeToMessageChannel(string ChannelId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, ChannelId);
        }
    }
}
