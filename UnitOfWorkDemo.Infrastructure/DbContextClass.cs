using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoho.Domain;

namespace UnitOfWorkDemo.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BillingMethod> BillingMethods { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var Currencies = new List<Currency>()
            {
                new Currency()
                {
                    Id = 1,
                    Code = "USD",
                    Country= "United States",
                    IsDeleted = false
                },
                new Currency()
                {
                    Id = 2,
                    Code = "INR",
                    Country= "India",
                    IsDeleted = false
                },
                new Currency()
                {
                    Id = 3,
                    Code = "EUR",
                    Country= "Germany",
                    IsDeleted = false
                },
                new Currency()
                {
                    Id = 4,
                    Code = "JPY",
                    Country= "Japan",
                    IsDeleted = false
                },
                new Currency()
                {
                    Id = 5,
                    Code = "AUD",
                    Country= "Australia",
                    IsDeleted = false
                },
            };

            var BillingMethods = new List<BillingMethod>()
            {
                new BillingMethod()
                {
                    Id = 1,
                    MethodType = "Hourly Job Rate",
                    IsDeleted = false
                },
                new BillingMethod()
                {
                    Id = 2,
                    MethodType = "Hourly User Rate",
                    IsDeleted = false
                },
                new BillingMethod()
                {
                    Id = 3,
                    MethodType = "Hourly User Rate - Jobs",
                    IsDeleted = false
                },
                new BillingMethod()
                {
                    Id = 4,
                    MethodType = "Hourly User Rate - Projects",
                    IsDeleted = false
                }
            };

            var Roles = new List<Role>()
            {
                new Role()
                {
                    Id = 1,
                    RoleName = "admin",
                    RoleCode = "Admin",
                    IsAuthorize = true,
                    IsDeleted = false
                },
                new Role()
                {
                    Id = 1,
                    RoleName = "customer",
                    RoleCode = "Customer",
                    IsAuthorize = false,
                    IsDeleted = false
                }
            };


            modelBuilder.Entity<Currency>().HasData(Currencies);
            modelBuilder.Entity<BillingMethod>().HasData(BillingMethods);
            modelBuilder.Entity<Role>().HasData(Roles);
        }

    }
}
