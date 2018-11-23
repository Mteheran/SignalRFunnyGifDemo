using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FunnyGif.Hubs
{
    public class MessageHub: Hub
    {
        public async Task SendMessage(string newMessage)
        {
            await Clients.All.SendAsync("RecieveMessage", newMessage);
        }
    }
}
