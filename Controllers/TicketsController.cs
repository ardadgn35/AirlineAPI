using AirlineAPI.Models;
using AirlineAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AirlineContext _context;

        public TicketsController(AirlineContext context)
        {
            _context = context;
        }

        // Buy Ticket
        [HttpPost("buy")]
        public async Task<IActionResult> BuyTicket([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Ticket data is required.");
            }

            var flight = await _context.Flights.FindAsync(ticket.FlightId);
            if (flight == null)
            {
                return NotFound(new { Status = "Flight not found" });
            }

            if (flight.Capacity <= 0)
            {
                return BadRequest(new { Status = "No available seats" });
            }

            flight.Capacity--;  // Decrease available seats
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return Ok(new { Status = "Successful" });
        }
    }
}
