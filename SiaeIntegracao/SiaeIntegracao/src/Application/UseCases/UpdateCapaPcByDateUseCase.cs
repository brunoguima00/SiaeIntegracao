using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class UpdateCapaPcByDateUseCase
    {
        private readonly ICapaPcOnlineRepository _capaPcOnlineRepository;
        public UpdateCapaPcByDateUseCase(ICapaPcOnlineRepository capaPcOnlineRepository)
        {
            _capaPcOnlineRepository = capaPcOnlineRepository;
        }
        public async Task<string> Execute(DateOnly datePc, string projeto, string status)
        {
            var result = await _capaPcOnlineRepository.UpdateCapaStatusByDate(datePc, projeto, status);

            if (result > 0)
            {
                return $"{result} registros atualizados com sucesso.";
            }
            else
            {
                return "Nenhum registro encontrado para atualizar.";
            }
        }
    }
}
