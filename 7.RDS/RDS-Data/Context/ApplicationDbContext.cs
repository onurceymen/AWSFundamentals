using Microsoft.EntityFrameworkCore;
using RDS_Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS_Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tedarikcimapp.c7eg0ia0s66y.eu-north-1.rds.amazonaws.com,1433;Database=tedarikcimapp;User ID=admin;Password=reallyStrongPwd123;");
        }
    }
}
