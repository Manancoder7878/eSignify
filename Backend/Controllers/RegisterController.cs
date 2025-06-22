using Backend.DTO;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AgreementDbContext _context;
        private readonly JwtService _jwtService;
        public RegisterController(AgreementDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if(user == null || !BCrypt.Net.BCrypt.Verify(model.Password,user.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        // POST api/<Register>
        [HttpPost("register")]
        public IActionResult Post([FromBody] Register model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email already registered.");
                return BadRequest(ModelState);
            }
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { message = "Registration successful." });
        }
    }
}
