using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusLib.WebAPI.Models;

namespace MusLib.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }
            return new ObjectResult(User);
        }

        // PUT: api/Users
        [HttpPut]
        public async Task<ActionResult<User>> PutUser(User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Users.Any(e => e.Id == User.Id))
            {
                return NotFound();
            }

            _context.Update(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return Ok(User);
        }

        // DELETE: api/Users/3
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var User = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();

            return Ok(User);
        }
    }
}
