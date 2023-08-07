using API.Data.Repositories;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWKM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly iSalaRepository _salaRepository;

        public SalaController(iSalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSala(int id)
        {
            return Ok(await _salaRepository.GetSala(id));

        }
        [HttpPut]
        public async Task<IActionResult> UpdateSala([FromBody] Sala sala)
        {
            if (sala == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _salaRepository.UpdateSala(sala);

            return NoContent();
        }
    }
}
