using DataBaseDemo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseDemo.Services
{

    /// <summary>
    /// dotnet ef migrations add InitialCreate --project DataBaseDemo.Services
    /// dotnet ef database update --project DataBaseDemo.Services
    /// </summary>
    public class InventoryContext : DbContext
    {


        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=GraphQLDB;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
