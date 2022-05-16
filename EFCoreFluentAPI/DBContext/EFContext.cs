using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreFluentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFluentAPI.DBContext
{
   public  class EFFluentContext : DbContext
    {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learning;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder dbContexttBuilder)
        {
            dbContexttBuilder.UseSqlServer(connectionString); ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("admin");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
