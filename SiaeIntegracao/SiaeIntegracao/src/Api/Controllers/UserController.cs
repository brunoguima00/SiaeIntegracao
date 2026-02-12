using Microsoft.AspNetCore.Mvc;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly AuthUserUseCase _authUserUseCase;

        public UserController(CreateUserUseCase createUserUseCase, AuthUserUseCase authUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
            _authUserUseCase = authUserUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto request)
        {
            try
            {
                var result = await _createUserUseCase.CreateUser(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> AuthUser([FromBody] LoginRequestDto request)
        {
            try
            {
                var result = await _authUserUseCase.AuthUser(request.Email, request.Password);
                if (result == null)
                {
                    return Unauthorized("Invalid email or password.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
