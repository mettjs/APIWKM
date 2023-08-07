using API.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWKM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeteriaController : ControllerBase
    {
        private readonly iCafeteriaRepository _cafeteriaRepository;

        public CafeteriaController(iCafeteriaRepository cafeteriaRepository)
        {
            _cafeteriaRepository = cafeteriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCafeterias()
        {
            return Ok(await _cafeteriaRepository.GetCafeterias());

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCombo(int Id)
        {
            return Ok(await _cafeteriaRepository.GetCombo(Id));
        }
    }
}
