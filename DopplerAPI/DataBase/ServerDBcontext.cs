using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DopplerAPI.DataBase
{
    public class ServerDBcontext:DbContext
    {
        public ServerDBcontext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    dbContextOptionsBuilder.UseSqlServer(Properties.Resources.DBConnectionString);
        //}
    }
}
