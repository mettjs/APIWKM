using API.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWKM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteleraController : ControllerBase
    {
        private readonly iCarteleraRepository _carteleraRepository;

        public CarteleraController(iCarteleraRepository carteleraRepository)
        {
            _carteleraRepository = carteleraRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarteleras()
        {
            return Ok(await _carteleraRepository.GetAllCarteleras());

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetbyId(int Id)
        {
            return Ok(await _carteleraRepository.GetbyId(Id));
        }
    }
}
