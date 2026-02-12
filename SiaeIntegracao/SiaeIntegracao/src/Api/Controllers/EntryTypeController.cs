using Microsoft.AspNetCore.Mvc;
using SiaeIntegracao.src.Application.UseCases;

namespace SiaeIntegracao.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryTypeController : ControllerBase
    {
        private readonly GetAllEntryTypeByProjetoUseCase _getAllEntryTypeByProjetoUseCase;

        public EntryTypeController(GetAllEntryTypeByProjetoUseCase getAllEntryTypeByProjetoUseCase)
        {
            _getAllEntryTypeByProjetoUseCase = getAllEntryTypeByProjetoUseCase;
        }
        [HttpGet("entryTypes/{ideProjeto}")]
        public async Task<IActionResult> GetAllEntryTypeByProjeto(string ideProjeto)
        {
         try
            {
                var result = await _getAllEntryTypeByProjetoUseCase.Execute(ideProjeto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao buscar tipos de lançamento.");
            }
        }
    }
}
