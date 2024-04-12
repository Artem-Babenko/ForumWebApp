using Microsoft.AspNetCore.SignalR;

namespace ForumWebApp.SignalRHubs;

public class ChatHub : Hub
{
    public async Task TakeMessage(int userId, string userName, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", userId, userName, message);
    }
}
