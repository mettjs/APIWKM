using API.Data.Repositories;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWKM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly iClientesRepository _clientesRepository;

        public ClientesController(iClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }
        [HttpPost]
        public async Task<IActionResult> InsertClientes([FromBody] Clientes clientes)
        {
            if (clientes == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clientesRepository.InsertClientes(clientes);

            return NoContent();
        }
        [HttpGet("{correo}")]
        public async Task<IActionResult> GetClientes(string correo)
        {
            return Ok(await _clientesRepository.GetClientes(correo));
        }
    }
}
