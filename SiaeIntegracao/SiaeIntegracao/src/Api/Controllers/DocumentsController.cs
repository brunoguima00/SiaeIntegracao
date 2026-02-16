using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiaeIntegracao.src.Application.UseCases;
using SiaeIntegracao.src.Domain.Dtos;
using System.Threading.Tasks;

namespace SiaeIntegracao.src.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly CreateDocumentsUseCase _createDocumentsUseCase;
        private readonly GetDocumentsByDateUseCase _getDocumentsByDateUseCase;
        private readonly DeleteDocumentByIdUseCase _deleteDocumentByIdUseCase;
        private readonly UpdateDocumentsStatusByDateUseCase _updateDocumentsStatusByDateUseCase;

        public DocumentsController(
            CreateDocumentsUseCase createDocumentsUseCase,
            GetDocumentsByDateUseCase getDocumentsByDateUseCase,
            DeleteDocumentByIdUseCase deleteDocumentByIdUseCase,
            UpdateDocumentsStatusByDateUseCase updateDocumentsStatusByDateUseCase)
        {
            _createDocumentsUseCase = createDocumentsUseCase;
            _getDocumentsByDateUseCase = getDocumentsByDateUseCase;
            _deleteDocumentByIdUseCase = deleteDocumentByIdUseCase;
            _updateDocumentsStatusByDateUseCase = updateDocumentsStatusByDateUseCase;
        }

        [HttpPost]
        [Route("createDocument")]
        public async Task<IActionResult> CreateDocument(DocumentsDto documents)
        {
            try
            {
                var result = await _createDocumentsUseCase.Execute(documents);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getDocumentsByDate/{projeto}/date/{date}")]
        public async Task<IActionResult> GetDocumentsByDate(string projeto, DateOnly date)
        {
            try
            {
                var result = await _getDocumentsByDateUseCase.Execute(projeto, date);
                if (result == null)
                {
                    return Ok(new List<DocumentsDto>());
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
        [HttpDelete]
        [Route("deleteDocumentById/{id}")]
        public async Task<IActionResult> DeleteDocumentById(long id)
        {
            try
            {
                var result = await _deleteDocumentByIdUseCase.Execute(id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Document not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("updateDocumentsStatusByDate/{date}/{projeto}/{status}")]
        public async Task<IActionResult> UpdateDocumentsStatusByDate(DateOnly date, string projeto, string status)
        {
            try
            {
                var result = await _updateDocumentsStatusByDateUseCase.Execute(date, projeto, status);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}