using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoho.Domain;

namespace Zoho.Dapper.Interfaces
{
    public interface IGenericRepository
    {
        //Task<Client> GetByIdAsync(int id);
        Task<IReadOnlyList<Client>> GetAllAsync();
        //Task<int> AddAsync(Client entity);
        //Task<int> UpdateAsync(Client entity);
        //Task<int> DeleteAsync(int id);
    }
}
