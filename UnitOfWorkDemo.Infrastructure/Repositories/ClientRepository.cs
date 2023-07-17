using Microsoft.Extensions.Configuration;
using UnitOfWorkDemo.Core.Interfaces;
using Zoho.Data;
using Zoho.Domain;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(IConfiguration configuration) : base(configuration, "Clients" )
        {

        }
    }
}
