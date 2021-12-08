using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.SignalR
{
    public class NotifyHubChannel : Hub<ITypedHubClient>
    {
    }
}
