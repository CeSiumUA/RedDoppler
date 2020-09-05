using DopplerAPI.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DopplerAPI.Chatting
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ChatsHub : Hub
    {
        private ServerDBcontext ServerDBcontext;
        public ChatsHub(ServerDBcontext serverDBcontext)
        {
            this.ServerDBcontext = serverDBcontext;
        }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Connected");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
