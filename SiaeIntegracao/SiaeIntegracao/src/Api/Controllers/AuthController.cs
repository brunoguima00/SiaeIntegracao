using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiaeIntegracao.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthUserUseCase _authUserUseCase;
        private readonly IConfiguration _configuration;
        public AuthController(AuthUserUseCase authUserUseCase, IConfiguration configuration)
        {
            _authUserUseCase = authUserUseCase;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<IActionResult> AuthUser([FromBody] LoginRequestDto request)
        {
            try
            {
                // 1. Valida as credenciais no banco
                var user = await _authUserUseCase.AuthUser(request.Email, request.Password);

                if (user == null)
                {
                    return Unauthorized("Invalid email or password.");
                }

                // 2. Se o usuário é válido, gera o Token JWT
                var token = GerarToken(user); // Método que cria a assinatura

                // 3. Retorna um DTO com o Token e dados básicos
                return Ok(new LoginResponseDto
                {
                    Token = token,
                    UserId = user.Id ?? 0,
                    Name = user.Name,
                    Email = user.Email
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private string GerarToken(UserDto usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim("Projeto", "Siae") // Você pode colocar claims customizados
        }),
                Expires = DateTime.UtcNow.AddHours(8), // Tempo de turno do operador
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
