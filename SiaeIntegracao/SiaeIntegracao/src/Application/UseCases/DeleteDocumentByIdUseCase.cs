using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class DeleteDocumentByIdUseCase
    {
        private readonly IDocumentsRepository _documentsRepository;
        public DeleteDocumentByIdUseCase(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }
        public async Task<bool> Execute(long id)
        {
            return await _documentsRepository.DeleteDocumentById(id);
        }
    }
}
