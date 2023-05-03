namespace Zoho.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNuber { get; set; }
        public string FaxNumber { get; set; }

        public CurrencyDto Currency { get; set; }   
        public BillingMethodDto BillingMethod { get; set; }
    }
}