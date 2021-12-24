using ChatApplication.Entity;
using ChatApplication.Repositories;
using ChatApplication.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private IMessageRepository messageRepository;
        private IHubContext<HubMessage, IHubMessageSubscribe> hubContext;

        public MessageController(IMessageRepository messageRepository, IHubContext<HubMessage, IHubMessageSubscribe> hubContext)
        {
            this.messageRepository = messageRepository;
            this.hubContext = hubContext;
        }

        [HttpGet("GetMessagesByChannel/{Id}")]
        public List<Message> GetMessagesByChannel(string Id)
        {
            return this.messageRepository.GetMessagesByChannel(Id);
        }

        [HttpPost("CreateMessage")]
        public Message CreateMessage([FromBody] CreateMessage CreateMessage)
        {
            var message = this.messageRepository.CreateMessage(CreateMessage.MessageText, CreateMessage.UserEmail, CreateMessage.ChannelId);
            if (message != null)
            {
                this.hubContext.Clients.Group(CreateMessage.ChannelId).messageAdded(message);
            }
            return message;
        }

        [HttpPut("DeleteMessage/{MessageId}")]
        public bool DeleteChannel(string MessageId)
        {
            var message = this.messageRepository.GetMessagesByMessageId(MessageId);
            var isMessageDeleted = this.messageRepository.DeleteMessage(MessageId);
            if (message!= null && isMessageDeleted)
            {
                this.hubContext.Clients.Group(message.Channel.ChannelId).messageDeleted(message);
            }
            return isMessageDeleted;
        }
    }
}