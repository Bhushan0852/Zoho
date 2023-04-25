using Microsoft.EntityFrameworkCore;
using Zoho.Domain;

namespace Zoho.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Currency> Currencies{ get; set; }
        public DbSet<BillingMethod> BillingMethods{ get; set; }


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



            modelBuilder.Entity<Currency>().HasData(Currencies);
            modelBuilder.Entity<BillingMethod>().HasData(BillingMethods);
        }

    }
}