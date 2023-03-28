using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightDocsSystem.Data;
using FlightDocsSystem.Models;
using AutoMapper;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FDSContext _context;
        private readonly IMapper _mapper;

        public UserController(FDSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            var usersVM = _mapper.Map<List<UserVM>>(users);
            return Ok(usersVM);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userVM = _mapper.Map<UserVM>(user);
            return Ok(userVM);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserVM userVM)
        {
            if (id != userVM.user_id)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userVM);
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserVM>> PostUser(UserVM userVM)
        {
            var user = _mapper.Map<User>(userVM);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            userVM.user_id = user.Id;

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userVM);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
