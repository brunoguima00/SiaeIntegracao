using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SiaeIntegracao.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly CreateUserUseCase _createUserUseCase;

        public UserController(CreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
           
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
        

    }
}
