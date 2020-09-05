using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DopplerLib.Authentication
{
    public class AuthenticatedUser
    {
        public string AccessToken { get; set; }
        public DateTime TokenIssued { get; set; }
        public DateTime TokenExpired { get; set; }
        public User User { get; set; }
        public static async Task<AuthenticatedUser> Authenticate(string userName, string Password)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/auth");
                LoginInstance loginInstance = new LoginInstance()
                {
                    Login = userName,
                    Password = Password
                };
                using (StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginInstance)))
                {
                    requestMessage.Content = stringContent;
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    try
                    {
                        var result = await httpClient.SendAsync(requestMessage);
                        var loggedUser = JsonConvert.DeserializeObject<AuthenticatedUser>(await result.Content.ReadAsStringAsync());
                        return loggedUser;
                    }
                    catch(Exception exc)
                    {
                        return null;
                    }
                }
            }
        }
    }
}
