using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Create(T t);
        Task<T> Delete(int id);
        Task<T> UpdateAsync(T t);

        Task<T> GetUser(string userName, string password);
    }
}
