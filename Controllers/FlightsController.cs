using AirlineAPI.Models;
using AirlineAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly AirlineContext _context;

        public FlightsController(AirlineContext context)
        {
            _context = context;
        }

        // Insert Flight
        [HttpPost("insert")]
        public async Task<IActionResult> InsertFlight([FromBody] Flight flight)
        {
            if (flight == null)
            {
                return BadRequest("Flight data is required.");
            }

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
            return Ok(new { Status = "Successful" });
        }

        // Report Flights With Capacity
        [HttpGet("report")]
        public async Task<IActionResult> ReportFlights([FromQuery] string from, [FromQuery] string to, [FromQuery] int capacity)
        {
            var flights = await _context.Flights
                .Where(f => f.From == from && f.To == to && f.Capacity >= capacity)
                .ToListAsync();

            if (flights.Count == 0)
            {
                return NotFound(new { Status = "No flights found" });
            }

            return Ok(flights);
        }
    }
}
