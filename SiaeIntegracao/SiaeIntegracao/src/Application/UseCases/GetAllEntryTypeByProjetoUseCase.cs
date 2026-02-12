using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class GetAllEntryTypeByProjetoUseCase
    {
        private readonly IEntryTypeRepository _entryTypeRepository;
        public GetAllEntryTypeByProjetoUseCase(IEntryTypeRepository entryTypeRepository)
        {
            _entryTypeRepository = entryTypeRepository;
        }
        public async Task<List<EntryTypeDto>> Execute(string ideProjeto)
        {
            return await _entryTypeRepository.GetAllEntryTypeByProjeto(ideProjeto);
        }
    }
}
