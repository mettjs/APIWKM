using API.Data.Repositories;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWKM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly iPeliculasRepository _peliculaRepository;

        public PeliculasController(iPeliculasRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeliculas()
        {
            return Ok(await _peliculaRepository.GetPeliculas());

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDetails(int Id)
        {
            return Ok(await _peliculaRepository.GetDetails(Id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertPeliculas([FromBody] Peliculas peliculas)
        {
            if (peliculas == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _peliculaRepository.InsertPeliculas(peliculas);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePeliculas(int id)
        {
            await _peliculaRepository.DeletePeliculas(new Peliculas { Id = id });

            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePeliculas([FromBody] Peliculas peliculas)
        {
            if (peliculas == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _peliculaRepository.UpdatePeliculas(peliculas);

            return NoContent();
        }
    }
}
