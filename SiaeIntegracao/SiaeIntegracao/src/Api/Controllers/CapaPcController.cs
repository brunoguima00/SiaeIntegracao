using Microsoft.AspNetCore.Mvc;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapaPcController : ControllerBase
    {
        private readonly CreateCapaPcUseCase _createCapaPcUseCase;

        public CapaPcController(CreateCapaPcUseCase createCapaPcUseCase)
        {
            _createCapaPcUseCase = createCapaPcUseCase;
        }
        [HttpPost]
        [Route("createCapaPC")]
        public async Task<IActionResult> CreateCapaPc(CapaPcOnlineDto capaPcOnlineDto)
        {
            try
            {
                var result = await _createCapaPcUseCase.Execute(capaPcOnlineDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
