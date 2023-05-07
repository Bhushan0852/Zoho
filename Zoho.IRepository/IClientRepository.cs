using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoho.Domain;
using Zoho.DTOs;

namespace Zoho.Interface
{
    public interface IClientRepository
    {
        Task<List<Currency>> GetAllCurrencyAsync();
        Task<List<BillingMethod>> GetAllBillingMethodAsync();
        Task<List<Client>> GetAllClientAsync();
        Task<Client> GetClientByIdAsync(int ClientId);
        Task<bool> CreateClientAsync(CreateClientDto requestClient);
        Task<Client> UpdateClientAsync(RequestClientDto requestClient);
        Task<bool> RemoveClientAsync(int ClientId);
    }
}
