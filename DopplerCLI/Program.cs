using DopplerLib;
using DopplerLib.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DopplerCLI
{
    public class Program
    {
        private static HubConnection _hubConnection;
        public static async Task Main(string[] args)
        {
            try
            {
                string Token = await GetToken();
                _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:5001/chats", options => { options.AccessTokenProvider = () => Task.FromResult(Token); }).WithAutomaticReconnect().Build();
                await _hubConnection.StartAsync();
                await GetContacts();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
            Console.ReadLine();
        }
        private static async Task GetContacts()
        {
            var contacts = await _hubConnection.InvokeAsync<IEnumerable<Contact>>("GetUserContacts");
        }
        private static async Task<string> GetToken()
        {

            using(HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/auth");
                LoginInstance loginInstance = new LoginInstance()
                {
                    Login = "fedir",
                    Password = "12345Aa-"
                };
                using (StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginInstance)))
                {
                    requestMessage.Content = stringContent;
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var result = (await httpClient.SendAsync(requestMessage));
                    var loggedUser = JsonConvert.DeserializeObject<AuthenticatedUser>(await result.Content.ReadAsStringAsync());
                    Console.WriteLine(JsonConvert.SerializeObject(loggedUser, Formatting.Indented));
                    return loggedUser.AccessToken;
                }
            }
        }
    }
    public class TestContext:DbContext
    {
        public TestContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DopplerDB;Trusted_Connection=true;");
        }
    }
}
