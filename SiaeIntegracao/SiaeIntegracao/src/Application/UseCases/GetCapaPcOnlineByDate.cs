using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class GetCapaPcOnlineByDate
    {
        private readonly ICapaPcOnlineRepository _capaPcOnlineRepository;
        public GetCapaPcOnlineByDate(ICapaPcOnlineRepository capaPcOnlineRepository)
        {
            _capaPcOnlineRepository = capaPcOnlineRepository;
        }
        public async Task<List<CapaPcOnlineDto>> Execute(string projeto, DateOnly datePc)
        {
            var result = await _capaPcOnlineRepository.GetCapaPcOnlineByDate(projeto, datePc);

            if (result == null || result.Count == 0)
            {
                throw new Exception($"Não há lançamentos para essa data!'{datePc}'.");
            }
            return result;
        }
    }
}