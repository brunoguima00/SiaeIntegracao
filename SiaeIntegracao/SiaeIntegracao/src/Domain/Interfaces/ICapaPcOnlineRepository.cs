using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface ICapaPcOnlineRepository
    {
        public Task<List<CapaPcOnlineDto>> GetCapaPcOnlineByDate(string projeto, DateOnly datePc);

        public Task<string> InsertCapaPcOnline(CapaPcOnlineDto capaPcOnlineDtos);

        public Task<int> UpdateCapaStatusByDate(DateOnly datePc, string projeto, string status);

        public Task<bool> DeleteCapaById(long id);
    }
}
