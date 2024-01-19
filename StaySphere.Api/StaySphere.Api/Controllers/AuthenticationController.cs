using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StaySphere.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginAsync(LoginRequest request)
        {
            var user = Authenticate(request.Login, request.Password);

            if (user is null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("StaySphere-Sekret-Key777777777777"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Phone));
            claimsForToken.Add(new Claim("name", user.Name));

            var jwtSecurityToken = new JwtSecurityToken(
                "StaySphere-api",
                "StaySphere",
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(2),
                signingCredentials);

            var token = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(token);
        }
        static User Authenticate(string login, string password)
        {
            return new User()
            {
                Login = login,
                Password = password,
                Name = "Diyor",
                Phone = "+99888888888"
            };
        }
    }
}
