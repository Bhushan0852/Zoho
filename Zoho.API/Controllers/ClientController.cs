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
            if(result != null)
            {
                foreach (var item in result)
                {
                    item.CurrencyCode = item.Currency.Code;
                    item.BillingMethodType = item.BillingMethod.MethodType;
                }
                return Ok(result);
            }

            return BadRequest("Not Found");
        }

        [HttpPost("getclientbyid")]
        public async Task<IActionResult> GetClientByIdAsync(int ClientId)
        {
            var data = await clientRepository.GetClientByIdAsync(ClientId);
            var result = mapper.Map<ClientDto>(data);
            return Ok(result);
        }

        [HttpPut("updateclientbyid")]
        public async Task<IActionResult> UpdateClientByIdAsync(RequestClientDto requestClient)
        {
            var data = await clientRepository.UpdateClientAsync(requestClient);
            var result = mapper.Map<ClientDto>(data);
            return Ok(result);
        }

        [HttpPost("addclient")]
        public async Task<IActionResult> AddClientAsync(CreateClientDto createClient)
        {
            var data = await clientRepository.CreateClientAsync(createClient);
            //var result = mapper.Map<ClientDto>(data);
            if(!data)
            {
                return BadRequest("Please check log");
            }
            return Ok("Record insert successfully");
        }

        [HttpDelete("removeclient")]
        public async Task<IActionResult> RemoveClientAsync(int ClientId)
        {
            var data = await clientRepository.RemoveClientAsync(ClientId);
            //var result = mapper.Map<ClientDto>(data);
            if (!data)
            {
                return BadRequest("Please check log");
            }
            return Ok("Record insert successfully");
        }
    }
}
