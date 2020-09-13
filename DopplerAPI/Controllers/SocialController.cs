using DopplerAPI.DataBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DopplerAPI.Controllers
{
    [Authorize]
    public class SocialController:ApiController
    {
        private ServerDBcontext ServerDBcontext { get; set; }
        public SocialController(ServerDBcontext serverDBcontext)
        {
            this.ServerDBcontext = serverDBcontext;
        }
        //TODO
        [Microsoft.AspNetCore.Mvc.HttpGet("/getcontact")]
        public async Task<IActionResult> GetConversationContactsByGuid(Guid id)
        {
            return null;
        }
    }
}
