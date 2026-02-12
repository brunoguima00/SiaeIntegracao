using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface IUnitRepository
    {
        public Task<List<FilialDto>> GetAllowedUnits(int userId);
    }
}
