using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface IEntryTypeRepository
    {
        public Task<List<EntryTypeDto>> GetAllEntryTypeByProjeto(string ideProjeto);
    }
}
