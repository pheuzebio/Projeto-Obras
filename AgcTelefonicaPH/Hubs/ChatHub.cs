using Microsoft.AspNetCore.SignalR;

namespace AgcTelefonicaPH.Hubs
{
    public class ChatHub : Hub
    {
        public async Task sendMessage(string user, string message)
        {
            await Clients.All.SendAsync("broadcastMessage", user, message);
        }
    }
}