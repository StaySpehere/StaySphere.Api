using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StaySphere.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StaySphere.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string _secretKey = "StaySphere-Sekret-Key777777777777";

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginAsync(LoginRequest request)
        {
            var user = await AuthenticateAsync(request.Login, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user?.Phone),
                new Claim("name", user?.Name)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "StaySphere-api",
                audience: "StaySphere",
                claims: claimsForToken,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(token);
        }

        private async Task<User?> AuthenticateAsync(string? login, string? password)
        { 
            await Task.Delay(100);

            if (login == "validuser" && password == "validpassword")
            {
                return new User
                {
                    Login = login,
                    Password = password,
                    Name = "Diyor",
                    Phone = "+99888888888"
                };
            }

            return null;
        }
    }
}
