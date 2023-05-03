using Microsoft.EntityFrameworkCore;
using Zoho.Data;
using Zoho.Domain;
using Zoho.DTOs;
using Zoho.Interface;

namespace Zoho.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext dbContext;

        public ClientRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Currency>> GetAllCurrencyAsync()
        {
            var data = await dbContext.Currencies.ToListAsync();
           //     .Select(c => new CurrencyDto()
           //{
           //    Id = c.Id,
           //    Code = c.Code,
           //    Country = c.Country
           //}).ToListAsync();

            return data;
            
        }

        public async Task<List<BillingMethod>> GetAllBillingMethodAsync()
        {
            var data = await dbContext.BillingMethods.ToListAsync();
            
            return data;

        }

        public async Task<List<Client>> GetAllClientAsync()
        {
            var data = await dbContext.Clients
                .Include(v => v.Currency)
                .Include(b => b.BillingMethod).ToListAsync();
            return data;
        }
    }
}