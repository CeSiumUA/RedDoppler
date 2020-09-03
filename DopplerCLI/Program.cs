using DopplerLib.Authentication;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DopplerCLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder().WithUrl("https://localhost:5001/", options => { options.AccessTokenProvider = async () => await GetToken(); }).Build();
        }
        private static async Task<string> GetToken()
        {
            return "token";
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
