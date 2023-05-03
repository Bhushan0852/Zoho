using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoho.Domain
{
    public class BillingMethod : Entity
    {
        public int Id { get; set; }
        public string MethodType { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
