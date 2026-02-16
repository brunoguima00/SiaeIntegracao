using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class DeleteCapaPcByIdUseCase
    {
        private readonly ICapaPcOnlineRepository _capaPcOnlineRepository;
        public DeleteCapaPcByIdUseCase(ICapaPcOnlineRepository capaPcOnlineRepository)
        {
            _capaPcOnlineRepository = capaPcOnlineRepository;
        }
        public async Task<bool> Execute(long id)
        {
            return await _capaPcOnlineRepository.DeleteCapaById(id);
        }
    }
}