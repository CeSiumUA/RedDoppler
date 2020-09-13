using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DopplerLib;
using DopplerLib.Social;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DopplerAPI.DataBase
{
    public class ServerDBcontext:DbContext
    {
        public DbSet<DopplerLib.User> Users { get; set; }
        public DbSet<ContactMember> ContactMembers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationMember> ConversationMembers { get; set; }
        public ServerDBcontext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    dbContextOptionsBuilder.UseSqlServer(Properties.Resources.DBConnectionString);
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
