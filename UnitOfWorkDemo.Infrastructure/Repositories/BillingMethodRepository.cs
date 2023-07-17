using Microsoft.Extensions.Configuration;
using UnitOfWorkDemo.Core.Interfaces;
using Zoho.Data;
using Zoho.Domain;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class BillingMethodRepository : GenericRepository<BillingMethod>, IBillingMethodRepository
    {
        public BillingMethodRepository(IConfiguration configuration) : base(configuration, "BillingMethods")
        {

        }
    }
}
