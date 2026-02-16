using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class GetDocumentsByDateUseCase
    {
        private readonly IDocumentsRepository _documentRepository;

        public GetDocumentsByDateUseCase(IDocumentsRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<DocumentsDto>> Execute(string projeto, DateOnly date)
        {
            var documents = await _documentRepository.GetDocumentsByDate(projeto, date);
            if (documents == null || documents.Count == 0)
            {
                throw new Exception($"Não há documentos para a data: {date}.");
            }
            return documents;
        }

    }
}
