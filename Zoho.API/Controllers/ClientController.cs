using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoho.DTOs;
using Zoho.Interface;

namespace Zoho.API.Controllers
{
    [Route("zoho/api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        [HttpGet("getcurrencyddl")]
        public async Task<IActionResult> GetCurrencyAsync()
        {
            var data = await clientRepository.GetAllCurrencyAsync();
            var result = mapper.Map<List<CurrencyDto>>(data);
            return Ok(result);
        }

        [HttpGet("getbillingmethoddl")]
        public async Task<IActionResult> GetBillingMethodAsync()
        {
            var data = await clientRepository.GetAllBillingMethodAsync();
            var result = mapper.Map<List<BillingMethodDto>>(data);
            return Ok(result);
        }

        [HttpGet("getclient")]
        public async Task<IActionResult> GetClientAsync()
        {
            var data = await clientRepository.GetAllClientAsync();
            var result = mapper.Map<List<ClientDto>>(data);
            return Ok(result);
        }
    }
}
