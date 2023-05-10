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
            var data = await dbContext.Currencies.Where(v => !v.IsDeleted).ToListAsync();
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
            var data = await dbContext.BillingMethods.Where(v => !v.IsDeleted).ToListAsync();

            return data;

        }

        public async Task<List<Client>> GetAllClientAsync()
        {
            var data = await dbContext.Clients.Where(v => !v.IsDeleted)
                .Include(v => v.Currency)
                .Include(b => b.BillingMethod).ToListAsync();
            return data;
        }

        public async Task<Client> GetClientByIdAsync(int ClientId)
        {
            var data = await dbContext.Clients.Where(c => c.Id == ClientId && !c.IsDeleted)
                                   .Include(v => v.Currency)
                                  .Include(n => n.BillingMethod).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Client> UpdateClientAsync(RequestClientDto requestClient)
        {
            Client client = await dbContext.Clients.FirstOrDefaultAsync(n => !n.IsDeleted && n.Id == requestClient.Id);

            if (client == null)
            {
                return new();
            }

            client.ClientName = requestClient.ClientName;
            client.EmailId = requestClient.EmailId;
            client.FirstName = requestClient.FirstName;
            client.LastName = requestClient.LastName;
            client.PhoneNumber = requestClient.PhoneNumber;
            client.MobileNuber = requestClient.MobileNuber;
            client.FaxNumber = requestClient.FaxNumber;
            client.CurrencyId = requestClient.CurrencyId;
            client.BillingMethodId = requestClient.BillingMethodId != null ? requestClient.BillingMethodId : null;


            var data = dbContext.Clients.Update(client);
            await dbContext.SaveChangesAsync();

            return client;
        }

        public async Task<bool> CreateClientAsync(CreateClientDto requestClient)
        {
            var isAvailable = dbContext.Clients.Any(c => c.ClientName.ToLower() == requestClient.ClientName.ToLower());
            if (!isAvailable)
            {
                //Client client = new Client();
                //client.ClientName = requestClient.ClientName;
                //client.EmailId = requestClient.EmailId;
                //client.FirstName = requestClient.FirstName;
                //client.LastName = requestClient.LastName;
                //client.PhoneNumber = requestClient.PhoneNumber;
                //client.MobileNuber = requestClient.MobileNuber;
                //client.FaxNumber = requestClient.FaxNumber;
                //client.CurrencyId = requestClient.CurrencyId;
                //client.BillingMethodId = requestClient.BillingMethodId != null ? requestClient.BillingMethodId : null;
                //var data = await dbContext.Clients.AddAsync(client);
                //await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveClientAsync(int ClientId)
        {
            var client = await dbContext.Clients.Where(v => v.Id == ClientId && !v.IsDeleted).FirstOrDefaultAsync();
            if(client == null)
            {
                return false;
            }
            client.IsDeleted = true;
            dbContext.Clients.Update(client);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}