using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiDemo.DAL
{
    public class ApiDemoContext : DbContext
    {
        public ApiDemoContext() : base("ApiConnection")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}