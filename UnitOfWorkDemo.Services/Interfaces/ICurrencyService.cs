using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoho.Domain;

namespace UnitOfWorkDemo.Services.Interfaces
{
    public interface ICurrencyService
    {
        //Task<bool> CreateClient(Client client);

        Task<IEnumerable<Currency>> GetAllCurrencies();

        //Task<Client> GetClientById(int clientId);

        //Task<bool> UpdateClient(Client client);

        //Task<bool> DeleteClient(int clientId);
    }
}
