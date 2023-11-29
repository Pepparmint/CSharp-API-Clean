using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // LOGINr
        [HttpPost("login/(username:string pass:string)")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            bool isValidUser = AuthenticateUser(loginRequest.Username!, loginRequest.Password!);

            if (!isValidUser)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = GenerateJwtToken();

            return Ok(new { Token = token });
        }

        private bool AuthenticateUser(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }
            return username == "string" && password == "string";
        }

        private string GenerateJwtToken()
        {
            string secretKey = _configuration["JwtSettings:SecretKey"]!;

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "Its Joeover"),
            new Claim(ClaimTypes.Role, "Admin"),
        };

            var key = Encoding.ASCII.GetBytes(secretKey);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}