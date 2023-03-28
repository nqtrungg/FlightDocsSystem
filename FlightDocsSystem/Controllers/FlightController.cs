using AutoMapper;
using FlightDocsSystem.Data;
using FlightDocsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FDSContext _context;
        private readonly IMapper _mapper;

        public FlightController(FDSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Flight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightVM>>> GetFlights()
        {
            var flights = await _context.Flights.Include(f => f.Aircraft).ToListAsync();
            var flightVMs = _mapper.Map<IEnumerable<FlightVM>>(flights);

            return Ok(flightVMs);
        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightVM>> GetFlight(int id)
        {
            var flight = await _context.Flights.Include(f => f.Aircraft).FirstOrDefaultAsync(f => f.FlightId == id);

            if (flight == null)
            {
                return NotFound();
            }

            var flightVM = _mapper.Map<FlightVM>(flight);

            return Ok(flightVM);
        }

        // PUT: api/Flight/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, FlightVM flightVM)
        {
            if (id != flightVM.flight_id)
            {
                return BadRequest();
            }

            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            _mapper.Map(flightVM, flight);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flight
        [HttpPost]
        public async Task<ActionResult<FlightVM>> PostFlight(FlightVM flightVM)
        {
            var flight = _mapper.Map<Flight>(flightVM);

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.FlightId }, _mapper.Map<FlightVM>(flight));
        }

        // DELETE: api/Flight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.FlightId == id);
        }
    }
}
