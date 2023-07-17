using Microsoft.Extensions.Configuration;
using UnitOfWorkDemo.Core.Interfaces;
using Zoho.Data;
using Zoho.Domain;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(IConfiguration configuration) : base(configuration, "Currencies")
        {

        }
    }
}
