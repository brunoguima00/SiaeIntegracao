using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsTypeController : ControllerBase
    {
        private readonly GetDocumentsTypeUseCase _getDocumentsTypeUseCase;
        public DocumentsTypeController(GetDocumentsTypeUseCase getDocumentsTypeUseCase)
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
