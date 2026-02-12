using Microsoft.AspNetCore.Mvc;
using SiaeIntegracao.src.Application.UseCases;

namespace SiaeIntegracao.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        private readonly GetAllowedUnitsUseCase _getAllowedUnitsUseCase;

        public UnitsController(GetAllowedUnitsUseCase getAllowedUnitsUseCase)
        {
            _getAllowedUnitsUseCase = getAllowedUnitsUseCase;
        }
        [HttpGet("allowed/{userId:int}")]
        public async Task<IActionResult> GetAllowedUnits(int userId)
        {
            try
            {
                var units = await _getAllowedUnitsUseCase.Execute(userId);

                if (units == null || !units.Any())
                    return NotFound("Nenhuma unidade encontrada para este usuário.");

                return Ok(units);
            }
            catch (Exception ex)
            {
                // Logue o erro aqui (ex: ILogger)
                return StatusCode(500, "Erro interno ao buscar unidades.");
            }
        }
    }
}
