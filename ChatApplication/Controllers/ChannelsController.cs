using ChatApplication.Entity;
using ChatApplication.Repositories;
using ChatApplication.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChannelController : ControllerBase
    {
        private IChannelRepository channelRepository;
        private IHubContext<NotifyHubChannel, ITypedHubClient> hubContext;

        public ChannelController(IChannelRepository channelRepository, IHubContext<NotifyHubChannel, ITypedHubClient> hubContext)
        {
            this.channelRepository = channelRepository;
            this.hubContext = hubContext;
        }

        [HttpGet("GetAllChannels")]
        public IEnumerable<Channel> GetAllChannels()
        {
            return this.channelRepository.GetAllChannels();
        }

        [HttpGet("GetChannelById/{ChannelId}")]
        public Channel GetChannelById(string ChannelId)
        {
            return this.channelRepository.GetChannelById(ChannelId);
        }

        [HttpPost("CreateChannel")]
        public Channel CreateChannel([FromBody] string ChannelName)
        {
            var channel = this.channelRepository.CreateChannel(ChannelName);
            if (channel != null)
            {
                this.hubContext.Clients.All.BroadCastChannel(channel);
            }
            return channel;
        }

        [HttpPut("DeleteChannel/{ChannelId}")]
        public bool DeleteChannel(string ChannelId)
        {
            return this.channelRepository.DeleteChannel(ChannelId);
        }
    }
}