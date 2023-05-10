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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getcurrencyddl")]
        public async Task<IActionResult> GetCurrencyAsync()
        {
            var data = await clientRepository.GetAllCurrencyAsync();
            var result = mapper.Map<List<CurrencyDto>>(data);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getbillingmethoddl")]
        public async Task<IActionResult> GetBillingMethodAsync()
        {
            var data = await clientRepository.GetAllBillingMethodAsync();
            var result = mapper.Map<List<BillingMethodDto>>(data);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("getclient")]
        public async Task<IActionResult> GetClientAsync()
        {
            var data = await clientRepository.GetAllClientAsync();

            List<ClientDto> result = new List<ClientDto>();
            
            foreach (var item in data)
            {
                ClientDto clientDto = new ClientDto()
                {
                    Id = item.Id,
                    ClientName = item.ClientName,
                    EmailId = item.EmailId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber,
                    MobileNuber = item.MobileNuber,
                    FaxNumber = item.FaxNumber,
                    CurrencyCode = item.Currency.Code,
                    BillingMethodType = item.BillingMethodId != null ? item.BillingMethod.MethodType : ""
                };
                clientDto.Currency = new CurrencyLabelDto()
                {
                    Id = item.Currency.Id,
                    Label = item.Currency.Code
                };

                clientDto.BillingMethod = new BillingMethodlabelDto()
                {
                    Id = item.BillingMethod != null ? item.BillingMethod.Id : null,
                    Label = item.BillingMethod != null ? item.BillingMethod.MethodType : ""
                };

                result.Add(clientDto);

            }

            if(result == null)
            {
                return BadRequest();
            }
            //var result = mapper.Map<List<ClientDto>>(data);
            //if(result != null)
            //{
            //    foreach (var item in result)
            //    {
            //        item.CurrencyCode = item.Currency.Code;
            //        item.BillingMethodType = item.BillingMethod.MethodType;
            //    }
            //    return Ok(result);
            //}

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("getclientbyid")]
        public async Task<IActionResult> GetClientByIdAsync(int ClientId)
        {
            var data = await clientRepository.GetClientByIdAsync(ClientId);
   
            var result = mapper.Map<ClientDetailDto>(data);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("updateclientbyid")]
        public async Task<IActionResult> UpdateClientByIdAsync(RequestClientDto requestClient)
        {
            var data = await clientRepository.UpdateClientAsync(requestClient);
            var result = mapper.Map<ClientDto>(data);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("addclient")]
        public async Task<IActionResult> AddClientAsync(CreateClientDto createClient)
        {
            var data = await clientRepository.CreateClientAsync(createClient);
            //var result = mapper.Map<ClientDto>(data);
            if(!data)
            {
                return BadRequest("ClientName Already Exist");
            }
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("removeclient")]
        public async Task<IActionResult> RemoveClientAsync(int ClientId)
        {
            var data = await clientRepository.RemoveClientAsync(ClientId);
            //var result = mapper.Map<ClientDto>(data);
            if (!data)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
