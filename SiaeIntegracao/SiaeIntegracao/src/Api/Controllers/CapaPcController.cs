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
        private readonly UpdateCapaPcByDateUseCase _updateCapaPcByDateUseCase;
        private readonly DeleteCapaPcByIdUseCase _deleteCapaPcByIdUseCase;

        public CapaPcController
            (CreateCapaPcUseCase createCapaPcUseCase,
            GetCapaPcOnlineByDate getCapaPcOnlineByDate,
            UpdateCapaPcByDateUseCase updateCapaPcByDateUseCase,
            DeleteCapaPcByIdUseCase deleteCapaPcByIdUseCase)
        {
            _createCapaPcUseCase = createCapaPcUseCase;
            _getCapaPcOnlineByDate = getCapaPcOnlineByDate;
            _updateCapaPcByDateUseCase = updateCapaPcByDateUseCase;
            _deleteCapaPcByIdUseCase = deleteCapaPcByIdUseCase;
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
                if (result == null)
                {
                    return Ok(new List<CapaPcOnlineDto>());
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, stack = ex.StackTrace, inner = ex.InnerException?.Message });
            }
        }
        [HttpPut]
        [Route("updateStatusByDate/{dataPc}/{projeto}/{status}")]
        public async Task<IActionResult> UpdateStatusByDate(DateOnly dataPc, string projeto, string status)
        {
            try
            {
                var result = await _updateCapaPcByDateUseCase.Execute(dataPc, projeto, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, stack = ex.StackTrace, inner = ex.InnerException?.Message });
            }
        }
        [HttpDelete]
        [Route("deleteCapaPcById/{id}")]

        public async Task<IActionResult> DeleteCapaPcById(long id)
        {
            try
            {
                var result = await _deleteCapaPcByIdUseCase.Execute(id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { message = "Capa PC not found." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, stack = ex.StackTrace, inner = ex.InnerException?.Message });
            }
        }
    }
}