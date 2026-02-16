using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class UpdateDocumentsStatusByDateUseCase
    {
        private readonly IDocumentsRepository _documentsRepository;
        public UpdateDocumentsStatusByDateUseCase(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }
        public async Task<string> Execute(DateOnly datePc, string projeto, string status)
        {
            var result =  await _documentsRepository.UpdateDocumentsStatusByDate(datePc, projeto, status);

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
