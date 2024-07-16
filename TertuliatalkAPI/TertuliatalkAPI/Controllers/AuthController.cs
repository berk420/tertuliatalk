using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;

namespace TertuliatalkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> GetUsers() // Tablonun ismi "user" olarak değiştirildi
        {
            return await _context.users.ToListAsync(); // Tablonun ismi "user" olarak değiştirildi
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateUser([FromBody] TertuliatalkAPI.Entities.userDto userDto)
        {
            Console.WriteLine($"Received email: {userDto.email}, password: {userDto.password}");
            var user = await _context.users.FirstOrDefaultAsync(u => u.email == userDto.email && u.password == userDto.password);
            if (user == null)
            {
                Console.WriteLine("Unauthorized access attempt.");
                return Unauthorized();
            }
            Console.WriteLine("User authenticated successfully.");
            // Kullanıcı bilgilerini içeren bir JSON nesnesi döndürün
            return Ok(new
            {
                user.email,
                user.name,
                user.role
            });
        }


        [HttpPost]
        public async Task<ActionResult<user>> PostUser(user user) // Tablonun ismi "user" olarak değiştirildi
        {
            _context.users.Add(user); // Tablonun ismi "user" olarak değiştirildi
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.id }, user); // Tablonun ismi "user" olarak değiştirildi
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<user>> GetUser(Guid id) // Tablonun ismi "user" olarak değiştirildi
        {
            var user = await _context.users.FindAsync(id); // Tablonun ismi "user" olarak değiştirildi

            if (user == null)
            {
                return NotFound();
            }

            return user; // Tablonun ismi "user" olarak değiştirildi
        }
    }
}
