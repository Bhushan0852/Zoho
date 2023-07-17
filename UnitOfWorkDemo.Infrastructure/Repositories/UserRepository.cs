using Microsoft.Extensions.Configuration;
using UnitOfWorkDemo.Core.Interfaces;
using Zoho.Data;
using Zoho.Domain;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration, "Users")
        {

        }
    }
}
