using DopplerLib.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DopplerCLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            HashingMachine hashingMachine = new HashingMachine("21288221");
            while (true)
            {
                Console.WriteLine(await hashingMachine.GenerateCompleteHash("user", "12345"));
                Console.ReadLine();
            }
        }
    }
    public class TestClass
    {
        public string TestName
        {
            get
            {
                return testName;
            }
            set
            {
                testName = value;
            }
        }
        [Key]
        public Guid Id { get; set; }
        private string testName { get; set; }
    }
    public class TestContext:DbContext
    {
        public DbSet<TestClass> TestClasses { get; set; }
        public TestContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=true;");
        }
    }
}
