using Microsoft.AspNetCore.Mvc;
using SiaeIntegracao.src.Application.UseCases;

namespace SiaeIntegracao.src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumetsTypeController : ControllerBase
    {
        private readonly GetDocumentsTypeUseCase _getDocumentsTypeUseCase;
        public DocumetsTypeController(GetDocumentsTypeUseCase getDocumentsTypeUseCase)
        {
            _getDocumentsTypeUseCase = getDocumentsTypeUseCase;
        }

        [HttpGet]
        [Route("get-documents-type")]
        public async Task<IActionResult> GetDocumentsType()
        {
            try
            {
                var result = await _getDocumentsTypeUseCase.Execute();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
