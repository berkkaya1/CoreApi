using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CoreApi.Controllers;

  [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration configuration;
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Auth([FromBody] User user)
        {
            IActionResult response = Unauthorized();

            if (user != null)
            {
                if (user.Username.Equals("test@email.com") && user.Password.Equals("a"))
                {
                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature
                    );

                    var subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                        new Claim(JwtRegisteredClaimNames.Email, user.Username),
                        new Claim(JwtRegisteredClaimNames.Name, "503 sınıfı"),
                    });

                    var expires = DateTime.UtcNow.AddMinutes(2);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }

            return response;
        }
    }