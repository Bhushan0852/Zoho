using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoho.Domain
{
    public class Role : Entity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }

        public IEnumerable<User> Users { get; set; }

    }
}
