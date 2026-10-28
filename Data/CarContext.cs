using Assignment_10._3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_10._3.Data
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "data source = localhost\\SQLEXPRESS;" +
                "initial catalog=CCAD23Car;" +
                "integrated security=True;" +
                "encrypt=False;" +
                "trustservercertificate=True;" +
                "MultipleActiveResultSets=True"
                );

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Make = "Ford", Model = "Explorer", Year = 2019, Price = 14600, VIN = 1}
                );
        }
    }
}
