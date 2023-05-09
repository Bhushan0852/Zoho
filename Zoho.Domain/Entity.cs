using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoho.Domain
{
    public class Entity
    {
        public bool IsDeleted { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }
        public string? UpdatedBy { get; set; }
    }
}