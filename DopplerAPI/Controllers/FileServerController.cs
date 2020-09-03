using DopplerLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Http;

namespace DopplerAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("/api/[controller]")]
    public class FileServerController:ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get([Microsoft.AspNetCore.Mvc.FromHeader] DopplerLib.File file)
        {
            string ActiveDirectory = @"F:\ProjectFiles\";
            return PhysicalFile(ActiveDirectory + file.FilePath, MediaTypeNames.Application.Octet, Path.GetFileNameWithoutExtension(file.FilePath));
        }
    }
}
