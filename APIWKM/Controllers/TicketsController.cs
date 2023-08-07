using API.Data.Repositories;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWKM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly iTicketRepository _ticketRepository;

        public TicketsController(iTicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTicket(int Id)
        {
            return Ok(await _ticketRepository.GetTicket(Id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] Tickets tickets)
        {
            if (tickets == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ticketRepository.CreateTicket(tickets);

            return NoContent();
        }
    }
}
