using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using DopplerAPI.Authentication;
using DopplerAPI.DataBase;
using DopplerLib;
using DopplerLib.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DopplerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ServerDBcontext ServerDBcontext { get; set; }
        public AuthenticationController(ServerDBcontext serverDBcontext)
        {
            this.ServerDBcontext = serverDBcontext;
        }
        [HttpPost("/auth")]
        public async Task<IActionResult> Authenticate([FromBody] LoginInstance loginInstance)
        {
            DopplerLib.User user = ServerDBcontext.Users.Where(x => x.UserName == loginInstance.Login).Include(x => x.Contact).FirstOrDefault();
            if (user != null)
            {
                if (HashingMachine.ComparePasswordEquality(user.PasswordHash, loginInstance.Password))
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    var currentTime = DateTime.Now;
                    var expireTime = currentTime.AddMinutes(TokenAuth.Lifetime);
                    JwtSecurityToken jwt = new JwtSecurityToken(issuer: TokenAuth.Issuer, audience: TokenAuth.Audience, notBefore: currentTime, claims: claimsIdentity.Claims, expires: expireTime, signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(TokenAuth.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                    var encodedJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
                    var response = new
                    {
                        AccessToken = encodedJWT,
                        TokenIssued = currentTime,
                        TokenExpired = expireTime,
                        User = user
                    };

                    return new JsonResult(response);
                }
                else
                {
                    return Forbid();
                }
            }
            return NotFound();
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody]RegisterInstance user)
        {
            if (!string.IsNullOrEmpty(user.Login.Login) && !string.IsNullOrEmpty(user.Login.Password))
            {
                string passHash = HashingMachine.HashPassword(user.Login.Password);
                await ServerDBcontext.Users.AddAsync(new DopplerLib.User() { PasswordHash = passHash, UserName = user.Login.Login, Contact = user.Contact });
                await ServerDBcontext.SaveChangesAsync();
                return await Authenticate(user.Login);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
