using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Entity
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Transport> Transport { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            builder.UseSqlServer("Server=localhost;Database=Transport;Trusted_Connection=True;");
        }
    }
}
