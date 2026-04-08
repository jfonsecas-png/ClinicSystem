using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(IUserManager userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public ApiResponse Login(User dto)
        {
            var response = new ApiResponse();
            try
            {
               
                var user = _userManager.Login(dto.Username!, dto.Password!);

                if (user == null)
                {
                    response.Result = "error";
                    response.Message = "Credenciales incorrectas";
                    return response;
                }

                
                var token = GenerateToken(user);

                response.Result = "ok";
                response.Data = new
                {
                    Token = token,
                    Role = user.Role,
                    Username = user.Username,
                    PatientId = user.PatientId
                };
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message;
            }
            return response;
        }

        private string GenerateToken(User user)
        {
            //qué datos van dentro del token: nombre, rol y PatientId del usuario
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.Role, user.Role!),
                new Claim("PatientId", user.PatientId?.ToString() ?? "0"),
                new Claim("UserId", user.Id.ToString())
            };

         
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Aquí instancio el JwtSecurityToken, con los claims, 8 horas de expiración y la firma
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credentials
            );

            
            return new JwtSecurityTokenHandler().WriteToken(token);//Lo convierte en string
        }
    }
}