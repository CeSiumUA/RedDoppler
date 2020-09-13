using DopplerAPI.DataBase;
using DopplerLib;
using DopplerLib.Messaging;
using DopplerLib.Social;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;

namespace DopplerAPI.Chatting
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ChatsHub : Hub
    {
        private ServerDBcontext ServerDBcontext;
        private User ConnectedUser;
        public ChatsHub(ServerDBcontext serverDBcontext)
        {
            this.ServerDBcontext = serverDBcontext;
        }
        public override Task OnConnectedAsync()
        {
            string IdentityName = this.Context.User.Identity.Name;
            Console.WriteLine($"[{DateTime.Now}]: User {IdentityName} Connected");
            ConnectedUser = ServerDBcontext.Users.Where(x => x.UserName == IdentityName).Include(x => x.Contact).FirstOrDefault();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task<IEnumerable<Contact>> GetUserContacts()
        {
            var ContactsMembers = ServerDBcontext.ContactMembers.Where(x => x.ContactOwner.Id == ConnectedUser.Contact.Id).Include(x => x.ContactReference).Select(x => x.ContactReference);
            return ContactsMembers;
        }
        public async Task<IEnumerable<Conversation>> GetConversations()
        {
            var Conversations = ServerDBcontext.ConversationMembers.Where(x => x.Contact.Id == ConnectedUser.Contact.Id).Include(x => x.Conversation).Select(x => x.Conversation);
            return Conversations;
        }
        public async Task<IEnumerable<Guid>> GetConversationMembersGuids(Guid ConversationId)
        {
            var Guids = ServerDBcontext.ConversationMembers.Include(x => x.Conversation).Where(x => x.Conversation.Id == ConversationId).Include(x => x.Contact).Select(x => x.Id);
            return Guids;
        }
        public async Task<IEnumerable<ConversationMember>> GetConversationMembers(Guid ConversationId)
        {
            var members = ServerDBcontext.ConversationMembers.Include(x => x.Conversation).Where(x => x.Conversation.Id == ConversationId).Include(x => x.Contact);
            return members;
        }
    }
}
