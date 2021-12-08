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
        private IHubContext<NotifyHubMessage, ITypedHubClient> hubContext;

        public MessageController(IMessageRepository messageRepository, IHubContext<NotifyHubMessage, ITypedHubClient> hubContext)
        {
            this.messageRepository = messageRepository;
            this.hubContext = hubContext;
        }

        [HttpGet("GetMessagesByChannel/{ChannelId}")]
        public List<Message> GetMessagesByChannel(string ChannelId)
        {
            return this.messageRepository.GetMessagesByChannel(ChannelId);
        }

        [HttpPost("CreateMessage")]
        public Message CreateMessage([FromBody] CreateMessage CreateMessage)
        {
            var message = this.messageRepository.CreateMessage(CreateMessage.MessageText, CreateMessage.UserEmail, CreateMessage.ChannelId);
            if (message != null)
            {
                this.hubContext.Clients.All.BroadCastMessage(message);
            }
            return message;
        }

        [HttpPut("DeleteMessage/{MessageId}")]
        public bool DeleteChannel(string MessageId)
        {
            return this.messageRepository.DeleteMessage(MessageId);
        }
    }
}