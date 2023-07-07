using System.ComponentModel.DataAnnotations;

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

        public CurrencyLabelDto Currency { get; set; }   
        public BillingMethodlabelDto? BillingMethod { get; set; }
    }

    public class RequestClientDto
    {
        //[Required]
        public int Id { get; set; }
        //[Required]
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }
        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNuber { get; set; }
        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Fax Number.")]
        public string FaxNumber { get; set; }

        //[Required]
        public int CurrencyId { get; set; }
        
        public int? BillingMethodId { get; set; }
    }

    public class CreateClientDto
    {
        //[Required]
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }
        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNuber { get; set; }
        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Fax Number.")]
        public string FaxNumber { get; set; }

        //[Required]
        public int CurrencyId { get; set; }
        public int? BillingMethodId { get; set; }
    }

    public class CurrencyLabelDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        //public string Code { get; set; }
        //public string Country { get; set; }
    }
    public class BillingMethodlabelDto
    {
        public int? Id { get; set; }
        //public string MethodType { get; set; }
        public string Label { get; set; }
    }


    public class ClientDetailDto
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
}