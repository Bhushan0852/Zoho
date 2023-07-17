using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Core.Model
{
    public class Client
    {
        //public int Id { get; set; }
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNuber { get; set; }
        public string FaxNumber { get; set; }
        public bool IsDeleted { get; set; }
        public int CurrencyId { get; set; }
        public int? BillingMethodId { get; set; }
    }
}
