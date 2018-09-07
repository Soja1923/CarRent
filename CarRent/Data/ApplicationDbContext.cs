using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarRent.Models;

namespace CarRent.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> GetUsers { get; set; }
        public DbSet<Address> GetAddresses { get; set; }
        public DbSet<Car> GetCars { get; set; }
        public DbSet<CarDetails> GetCarDetails { get; set; }
        public DbSet<Person> GetPeople { get; set; } 
        public DbSet<Grade> GetGrades { get; set; }
        public DbSet<Location> GetLocations { get; set; }
        public DbSet<Order> GetOrders { get; set; }
        public DbSet<UserRating> GetUserRatings { get; set; }
        public DbSet<Employee> GetEmployees { get; set; }
        public DbSet<Customer> GetCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
