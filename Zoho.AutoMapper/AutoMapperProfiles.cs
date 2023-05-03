using AutoMapper;
using Zoho.Domain;
using Zoho.DTOs;

namespace Zoho.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<BillingMethod, BillingMethodDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
}