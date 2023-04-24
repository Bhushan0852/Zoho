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
        public async Task<List<CurrencyDto>> GetAllAsync()
        {
           var data =  await dbContext.Currencies.Select(c => new CurrencyDto()
           {
               Id = c.Id,
               Code = c.Code,
               Country = c.Country
           }).ToListAsync();

            return data;
            //return data.Select(c => new
            //{
            //    Id = c.Id,
            //    Code = c.Code,
            //    Country = c.Country
            //}).ToList();
        }
    }
}