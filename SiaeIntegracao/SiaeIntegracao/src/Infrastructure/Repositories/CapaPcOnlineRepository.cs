using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Entities;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;

namespace SiaeIntegracao.src.Infrastructure.Repositories
{
    public class CapaPcOnlineRepository : ICapaPcOnlineRepository
    {
        private readonly AppDbContext _context;

        public CapaPcOnlineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CapaPcOnlineDto>> GetCapaPcOnlineByDate(string projeto, DateOnly datePc)
        {
            return await (from capa in _context.PfCapaPcOnlines
                          join tipo in _context.PfTipoLanctos on capa.IdeLancamento equals tipo.IdeLancamento
                          where capa.DataPc == datePc && capa.IdePojeto == projeto
                          select new CapaPcOnlineDto
                          {
                              IdLancamento = capa.IdLancamento,
                              DataPc = capa.DataPc,
                              IdeLancamento = capa.IdeLancamento,
                              NomeLancamento = tipo.DescricaoLancamento, // Aqui vem o nome da tabela de cadastro
                              Quantidade = capa.Quantidade,
                              Valor = capa.Valor,
                              Status = capa.Status
                          }).ToListAsync();
        }

        public async Task<string> InsertCapaPcOnline(CapaPcOnlineDto dto)
        {

            var entity = new PfCapaPcOnline
            {
                IdeEmpresa = dto.IdeEmpresa,
                IdePojeto = dto.IdePojeto,
                DataPc = dto.DataPc,
                IdeFilial = dto.IdeFilial,
                IdeClasse = dto.IdeClasse,
                IdeLancamento = dto.IdeLancamento,
                OrdemLancamento = dto.OrdemLancamento,
                Quantidade = dto.Quantidade,
                Valor = dto.Valor,
                Modalidade = dto.Modalidade,
                IdeDocumento = dto.IdeDocumento,
                UsuarioCriou = dto.UsuarioCriou,
                DataCriacao = dto.DataCriacao,
                Importado = dto.Importado,
                Status = "Processando"

            };
            await _context.PfCapaPcOnlines.AddAsync(entity);

            await _context.SaveChangesAsync();
            return "Inserção concluída com sucesso.";
        }

        public async Task<int> UpdateCapaStatusByDate(DateOnly datePc, string projeto, string status)
        {
            // Executa o UPDATE direto no SQL Server em uma única linha
            var linhasAfetadas = await _context.PfCapaPcOnlines
                .Where(c => c.DataPc == datePc && c.IdePojeto == projeto)
                .ExecuteUpdateAsync(s => s.SetProperty(c => c.Status, status));

            return linhasAfetadas;
        }
        public async Task<bool> DeleteCapaById(long id)
        {
            var deleted = await _context.PfCapaPcOnlines.Where(c => c.IdLancamento == id).ExecuteDeleteAsync();

            return deleted > 0; // Retorna true se pelo menos um registro foi deletado
        }
    }
}