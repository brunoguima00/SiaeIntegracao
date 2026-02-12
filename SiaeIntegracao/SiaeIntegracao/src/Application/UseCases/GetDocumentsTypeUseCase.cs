using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class GetDocumentsTypeUseCase
    {
        private readonly IDocumentsType _documentsTypeRepository;
        public GetDocumentsTypeUseCase(IDocumentsType documentsTypeRepository)
        {
            _documentsTypeRepository = documentsTypeRepository;
        }
        public async Task<List<DocumentsTypeDto>> Execute()
        {
            return await _documentsTypeRepository.GetAllDocumentsType();
        }
    }
}