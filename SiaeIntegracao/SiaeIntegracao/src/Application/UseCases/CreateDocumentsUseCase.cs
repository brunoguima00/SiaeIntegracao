using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class CreateDocumentsUseCase
    {
        private readonly IDocumentsRepository _documentsRepository;

        public CreateDocumentsUseCase(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }

        public async Task<string> Execute(DocumentsDto documentsDto)
        {
            await _documentsRepository.CreateDocument(documentsDto);

            return "Documento salvo com sucesso";
        }
    }
}
