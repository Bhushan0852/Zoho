using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoho.DTOs;
using Zoho.Interface;

namespace Zoho.API.Controllers
{
    [Route("zoho/api/[controller]")]
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

        [HttpGet("get_all_currency")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await clientRepository.GetAllAsync();
            var result = mapper.Map<List<CurrencyDto>>(data);
            return Ok(result);
        }
    }
}
