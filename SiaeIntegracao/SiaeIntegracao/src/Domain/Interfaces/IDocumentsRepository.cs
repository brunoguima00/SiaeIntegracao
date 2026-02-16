using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface IDocumentsRepository
    {
        public  Task<string> CreateDocument(DocumentsDto document);
        public  Task<List<DocumentsDto>> GetDocumentsByDate(string projeto,DateOnly date);
        public  Task<bool> DeleteDocumentById(long id);

        public Task<int> UpdateDocumentsStatusByDate(DateOnly datePc, string projeto, string status);
    }
}
