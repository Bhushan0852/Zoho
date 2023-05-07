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
        public string CurrencyCode { get; set; }
        public string BillingMethodType { get; set; }

        public CurrencyDto Currency { get; set; }   
        public BillingMethodDto BillingMethod { get; set; }
    }

    public class RequestClientDto
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
        public int BillingMethodId { get; set; }
    }

    public class CreateClientDto
    {
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNuber { get; set; }
        public string FaxNumber { get; set; }
        public int CurrencyId { get; set; }
        public int BillingMethodId { get; set; }
    }
}