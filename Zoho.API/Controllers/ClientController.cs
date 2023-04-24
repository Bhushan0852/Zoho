using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoho.Interface;

namespace Zoho.API.Controllers
{
    [Route("zoho/api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet("get_all_currency")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await clientRepository.GetAllAsync();
            return Ok(data);
        }
    }
}
