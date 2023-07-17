using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Core.Interfaces
{
    public interface IRoleRepository<T> where T : class
    {
        Task<bool> AuthenticateAsync();
    }
}
