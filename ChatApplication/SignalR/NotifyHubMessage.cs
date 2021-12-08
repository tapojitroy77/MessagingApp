using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.SignalR
{
    public class NotifyHubMessage : Hub<ITypedHubClient>
    {
    }
}
