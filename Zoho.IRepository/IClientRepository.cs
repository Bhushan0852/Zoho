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
        Task<List<Currency>> GetAllAsync();
    }
}
