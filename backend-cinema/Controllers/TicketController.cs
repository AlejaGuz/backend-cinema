using backend_cinema.Services;
using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetTicketsAsync() 
        {
            try
            {
                var tickets = await _ticketService.GetTicketsAsync();
                return Ok(tickets);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{TicketID:int}", Name = "GetTicketById")]
        public async Task<ActionResult<Ticket>> GetTicketByIdAsync(int TicketID)
        {
            try
            {
                var ticket = await _ticketService.GetTicketByIdAsync(TicketID);
                if (ticket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("show/{ShowID:int}")]
        public async Task<ActionResult<List<Ticket>>> GetTicketsByShowAsync(int ShowID)
        {
            try
            {
                var tickets = await _ticketService.GetTicketsByShowAsync(ShowID);

                return Ok(tickets);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> AddTicketAsync(Ticket Ticket)
        {
            try
            {
                var saveTicket = await _ticketService.AddTicketAsync(Ticket);
                return CreatedAtRoute("GetTicketById", 
                    new { TicketID =  saveTicket.TicketId }, saveTicket);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Ticket>> UpdateTicketAsync(Ticket Ticket)
        {
            try
            {
                var updatedTicket = await _ticketService.UpdateTicketAsync(Ticket);
                return Ok(updatedTicket);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{TicketID:int}")]
        public async Task<IActionResult> DeleteTicketAsync(int TicketID)
        {
            try
            {
                await _ticketService.DeleteTicketAsync(TicketID);

                return Ok("Ticket Removed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
