using ChatApplication.Entity;
using ChatApplication.Repositories;
using ChatApplication.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Controllers
{
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private IChannelRepository channelRepository;
        private IHubContext<HubMessage, IHubMessageSubscribe> hubContext;

        public ChannelController(IChannelRepository channelRepository, IHubContext<HubMessage, IHubMessageSubscribe> hubContext)
        {
            this.channelRepository = channelRepository;
            this.hubContext = hubContext;
        }

        [HttpGet("channels")]
        public IEnumerable<Channel> GetAllChannels()
        {
            return this.channelRepository.GetAllChannels();
        }

        [HttpGet("channels/{Id}")]
        public Channel GetChannelById(string Id)
        {
            return this.channelRepository.GetChannelById(Id);
        }

        [HttpPost("channels")]
        public Channel CreateChannel([FromBody] ChannelRequest channel)
        {
            var createdChannel = this.channelRepository.CreateChannel(channel.Name);
            return createdChannel;
        }

        [HttpDelete("channels/{Id}")]
        public bool DeleteChannel(string Id)
        {
            var isChannelDeleted = this.channelRepository.DeleteChannel(Id);
            this.hubContext.Clients.Group(Id).channelDeleted();
            return isChannelDeleted;
        }
    }
} 