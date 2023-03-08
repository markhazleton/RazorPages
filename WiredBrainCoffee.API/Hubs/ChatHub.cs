using Microsoft.AspNetCore.SignalR;
using System;
using System.Diagnostics;
using System.Linq;

namespace WiredBrainCoffee.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Debug.WriteLine("Hub execution");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
