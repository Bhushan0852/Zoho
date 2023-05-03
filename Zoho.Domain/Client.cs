namespace Zoho.Domain
{
    public class Client : Entity
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNuber { get; set; }
        public string FaxNumber { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int BillingMethodId { get; set; }
        public virtual BillingMethod BillingMethod { get; set; }
    }
}