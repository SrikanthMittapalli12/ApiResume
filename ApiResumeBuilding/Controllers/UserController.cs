using ApiResumeBuilding.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiResumeBuilding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ResumeBuildContext _context;

        public UserController(ResumeBuildContext context)
        {
            _context = context;
        }






        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(User user)
            {
            // Check if the provided password is null or empty
            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                return BadRequest("Password cannot be null or empty.");
            }

            // Check if a user with the same email already exists
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return BadRequest("A user with this email already exists.");
            }

            // Hash the user's password before saving it
            user.PasswordHash = HashPassword(user.PasswordHash);

            // Add the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully." });

        }


        // Private method to hash passwords (use your preferred password hashing library)
        private string HashPassword(string password)
        {
            // Implement password hashing logic here (e.g., using BCrypt)
            // Example: return BCrypt.Net.BCrypt.HashPassword(password);
            // Generate a salt (automatically handled by BCrypt)
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash the password with the salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }




        // POST: api/User/login (Login)
        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Retrieve the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            // Verify the entered password against the stored hash
            if (VerifyPassword(password, user.PasswordHash))
            {
                // Password is correct, allow the user to log in
                return Ok(new { message = "Login successful." });
            }
            else
            {
                // Password is incorrect, deny access
                return Unauthorized(new { message = "Incorrect password." });
            }
        }


        // Private method to verify passwords (use your preferred password hashing library)
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            // Implement password verification logic here (e.g., using BCrypt)
            // Example: return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
            // Use BCrypt to verify the entered password against the stored hash
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);

            return isPasswordValid;
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }




        // GET: api/User (Get all users)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return  _context.Users.ToList();
        }

        // GET: api/User/5 (Get user by ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User (Create user)
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            // Check if a user with the same email already exists
            if ( _context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("A user with this email already exists.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // PUT: api/User/5 (Update user by ID)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

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

        // DELETE: api/User/5 (Delete user by ID)
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
            return _context.Users.Any(e => e.UserId == id);
        }

    }
}
