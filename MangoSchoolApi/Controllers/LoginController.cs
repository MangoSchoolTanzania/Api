using MangoSchoolApi.Data;
using MangoSchoolApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MangoSchoolApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("/v1/Login")]
        public async Task<IActionResult> Login([FromServices] MangoDataContext context, [FromBody]LoginViewModel credentials)
        {
            try
            {
                if(credentials == null) { return StatusCode(400, " The credentials provided are not valid"); }

                var isValidUser = await IsValidUser(context, credentials.Email, credentials.Password);

                if (isValidUser)
                {
                    var token = GenerateJwtToken(credentials.Email);
                    return Ok(new { token });
                }

                return Unauthorized();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<bool> IsValidUser(MangoDataContext Context, string email, string password)
        {
            var user = await Context.Users.FirstOrDefaultAsync(x => x.UserEmail == email && x.Password == password);
            if (user != null) { return true; }

            return false;
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(JwtRegisteredClaimNames.Aud, _configuration["JwtSettings:Audience"]),
                    new Claim(JwtRegisteredClaimNames.Iss, _configuration["JwtSettings:Issuer"])
                 }),
                Expires = DateTime.UtcNow.AddHours(8), // Set token expiration time
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
