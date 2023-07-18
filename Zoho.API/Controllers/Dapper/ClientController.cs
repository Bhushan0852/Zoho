using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Interfaces;
using Zoho.Domain;
using Zoho.DTOs;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Zoho.API.Controllers.Dapper
{
    [ApiController]
    [Route("controller")]
    
    public class ClientController : ControllerBase
    {
        public readonly UnitOfWorkDemo.Core.Interfaces.IClientRepository clientRepository;
        public readonly UnitOfWorkDemo.Core.Interfaces.ICurrencyRepository currencyRepository;
        public readonly UnitOfWorkDemo.Core.Interfaces.IBillingMethodRepository billingMethodRepository;
        private readonly IMapper mapper;
        public ClientController(UnitOfWorkDemo.Core.Interfaces.IClientRepository clientRepository,
            UnitOfWorkDemo.Core.Interfaces.ICurrencyRepository currencyRepository,
            IBillingMethodRepository billingMethodRepository , IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.currencyRepository = currencyRepository;
            this.billingMethodRepository = billingMethodRepository;
            this.mapper = mapper;
        }

        [HttpGet("zoho/dapper/api/client/getclientlist")]
        [Authorize(Roles = "ProjectHead,SuperAdmin")]
        public async Task<IActionResult> GetAllClients()
        {
            //throw new Exception("somthing went wrong");
            var result = await clientRepository.GetAll();
            if (result != null)
            {
                List<ClientDto> clients = new List<ClientDto>();

                foreach (var item in result)
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
                        CurrencyId = item.CurrencyId,
                        BillingMethodId = item.BillingMethodId
                    };
                    var currencyDetail = await currencyRepository.GetById(clientDto.CurrencyId);
                    clientDto.Currency = new CurrencyLabelDto()
                    {
                        Id = item.CurrencyId,
                        Label = currencyDetail.Code
                    };

                    if (clientDto.BillingMethodId != null && clientDto.BillingMethodId > 0)
                    {
                        var billingMethodId = clientDto.BillingMethodId != null ? clientDto.BillingMethodId : 0;
                        var billingDetail = await billingMethodRepository.GetById((int)billingMethodId);
                        clientDto.BillingMethod = new BillingMethodlabelDto()
                        {
                            Id = item.BillingMethodId,
                            Label = billingDetail.MethodType
                        };
                    }
                    clients.Add(clientDto);
                }
                return Ok(clients);
            }
            return NotFound();
        }

        [HttpGet("zoho/dapper/api/client/getcurrencylist")]
        [Authorize(Roles = "ProjectHead,SuperAdmin")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await currencyRepository.GetAll();
            if (result != null)
            {
                var currencies = mapper.Map<List<CurrencyDto>>(result);
                return Ok(currencies);
            }
            return NotFound(); 
        }

        [HttpGet("zoho/dapper/api/client/getbillingmethodlist")]
        [Authorize(Roles = "ProjectHead,SuperAdmin")]
        public async Task<IActionResult> GetAllBillingMethods()
        {
            var result = await billingMethodRepository.GetAll();
            if (result != null)
            {
               var billingDetail = mapper.Map<List<BillingMethodDto>>(result);
                return Ok(billingDetail);
            }
            return NotFound();
        }

        [HttpGet("zoho/dapper/api/client/clientId")]
        [Authorize(Roles = "ProjectHead,SuperAdmin")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            ClientDto clientDto = new ClientDto();
            var result = await clientRepository.GetById(clientId);
            if (result != null)
            {
                clientDto = new ClientDto()
                    {
                        Id = result.Id,
                        ClientName = result.ClientName,
                        EmailId = result.EmailId,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        PhoneNumber = result.PhoneNumber,
                        MobileNuber = result.MobileNuber,
                        FaxNumber = result.FaxNumber,
                        CurrencyId = result.CurrencyId,
                        BillingMethodId = result.BillingMethodId
                    };
                    var currencyDetail = await currencyRepository.GetById(clientDto.CurrencyId);
                    clientDto.Currency = new CurrencyLabelDto()
                    {
                        Id = result.CurrencyId,
                        Label = currencyDetail.Code
                    };

                    if (clientDto.BillingMethodId != null && clientDto.BillingMethodId > 0)
                    {
                        var billingMethodId = clientDto.BillingMethodId != null ? clientDto.BillingMethodId : 0;
                        var billingDetail = await billingMethodRepository.GetById((int)billingMethodId);
                        clientDto.BillingMethod = new BillingMethodlabelDto()
                        {
                            Id = result.BillingMethodId,
                            Label = billingDetail.MethodType
                        };
                    }
                return Ok(clientDto);
            }
            return NotFound();
        }

        [HttpPut("zoho/dapper/api/client/updateclient")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> UpdateClient(UpdateClientDto updateClient)
        {
            if (updateClient != null)
            {
                Client client = new Client()
                {
                    Id = updateClient.Id,
                    ClientName = updateClient.ClientName,
                    EmailId = updateClient.EmailId,
                    FirstName = updateClient.FirstName,
                    LastName = updateClient.LastName,
                    PhoneNumber = updateClient.PhoneNumber,
                    MobileNuber = updateClient.MobileNuber,
                    FaxNumber = updateClient.FaxNumber,
                    CurrencyId = updateClient.CurrencyId,
                    BillingMethodId = updateClient.BillingMethodId,
                    IsDeleted = false
                };
                var result = await clientRepository.UpdateAsync(client);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("zoho/dapper/api/client/clientId")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            var result = await clientRepository.Delete(clientId);

            if (result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("zoho/dapper/api/client/createclient")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> CreateClient(CreateClientDto addClient)
        {
            var userName = HttpContext.User.Identity.Name;
            Client client = new Client()
            {
                ClientName = addClient.ClientName,
                EmailId = addClient.EmailId,
                FirstName = addClient.FirstName,
                LastName = addClient.LastName,
                PhoneNumber = addClient.PhoneNumber,
                MobileNuber = addClient.MobileNuber,
                FaxNumber = addClient.FaxNumber,
                CurrencyId = addClient.CurrencyId,
                BillingMethodId = addClient.BillingMethodId,
                IsDeleted = false
            };

            var result = await clientRepository.Create(client);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
