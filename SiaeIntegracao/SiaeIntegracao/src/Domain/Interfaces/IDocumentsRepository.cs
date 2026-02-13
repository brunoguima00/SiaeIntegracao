using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface IDocumentsRepository
    {
        public Task<string> CreateDocument(DocumentsDto document);
        public Task<List<DocumentsDto>> GetDocumentsByDate(DateOnly date);
    }
}
