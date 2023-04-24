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

    }
}