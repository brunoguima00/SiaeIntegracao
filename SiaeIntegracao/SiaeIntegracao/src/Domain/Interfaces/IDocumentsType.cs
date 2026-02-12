using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface IDocumentsType
    {
        public Task<List<DocumentsTypeDto>> GetAllDocumentsType();
    }
}
