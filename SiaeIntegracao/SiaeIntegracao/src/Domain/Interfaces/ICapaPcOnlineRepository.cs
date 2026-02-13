using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface ICapaPcOnlineRepository
    {
        public Task<List<CapaPcOnlineDto>> GetCapaPcOnlineByDate(string projeto, DateOnly datePc);

        public Task<string> InsertCapaPcOnline(CapaPcOnlineDto capaPcOnlineDtos);
    }
}
