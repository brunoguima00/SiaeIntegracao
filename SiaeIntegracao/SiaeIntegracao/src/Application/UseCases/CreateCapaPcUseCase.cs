using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class CreateCapaPcUseCase
    {
        private readonly ICapaPcOnlineRepository _capaPcOnlineRepository;

        public CreateCapaPcUseCase(ICapaPcOnlineRepository capaPcOnlineRepository)
        {
            _capaPcOnlineRepository = capaPcOnlineRepository;
        }

        public async Task<string> Execute(CapaPcOnlineDto capaPcOnlineDto)

        {
            return await _capaPcOnlineRepository.InsertCapaPcOnline(capaPcOnlineDto);
        }
    }
}
