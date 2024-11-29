using AirlineAPI.Models;
using AirlineAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly AirlineContext _context;

        public CheckInController(AirlineContext context)
        {
            _context = context;
        }

        // Check in a flight
        [HttpPost]
        [Route("checkin/{ticketId}")]
        public async Task<IActionResult> CheckIn(int ticketId)
        {
            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null)
            {
                return NotFound("Ticket not found");
            }

            if (ticket.IsCheckedIn)
            {
                return BadRequest("Ticket has already been checked in.");
            }

            // Flight bilgilerini almak için FlightId üzerinden sorgu yap
            var flight = await _context.Flights
                .FirstOrDefaultAsync(f => f.Id == ticket.FlightId);

            if (flight == null)
            {
                return BadRequest("Associated flight not found.");
            }

            // Check-in işlemi
            ticket.IsCheckedIn = true;

            // Veritabanını güncelleme
            await _context.SaveChangesAsync();

            // Check-in sonrası response
            return Ok(new
            {
                status = "Successful",
                message = "Ticket has been successfully checked in.",
                passengerName = ticket.PassengerName, // Bilet sahibinin adı
                flight = new
                {
                    from = flight.From,
                    to = flight.To,
                    date = flight.Date
                }
            });
        }
    }
}
