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
        private readonly GetCapaPcOnlineByDate _getCapaPcOnlineByDate;

        public CapaPcController(CreateCapaPcUseCase createCapaPcUseCase, GetCapaPcOnlineByDate getCapaPcOnlineByDate)
        {
            _createCapaPcUseCase = createCapaPcUseCase;
            _getCapaPcOnlineByDate = getCapaPcOnlineByDate;
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
        [HttpGet]
        [Route("getCapaPCByDate/{projeto}/date/{datePc}")]
        public async Task<IActionResult> GetCapaPcByDate(string projeto, DateOnly datePc)
        {
            try
            {
                var result = await _getCapaPcOnlineByDate.Execute(projeto, datePc);
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