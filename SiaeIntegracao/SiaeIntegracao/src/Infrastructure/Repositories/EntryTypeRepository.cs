using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;

namespace SiaeIntegracao.src.Infrastructure.Repositories
{
    public class EntryTypeRepository : IEntryTypeRepository
    {
        private readonly AppDbContext _context;

        public EntryTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EntryTypeDto>> GetAllEntryTypeByProjeto(string ideProjeto)
        {
            return await _context.PfTipoLanctos
                .Where(et => et.IdeProjeto == ideProjeto)
                .Select(et => new EntryTypeDto
                {
                   IdeLancamento = et.IdeLancamento,
                   IdeEmpresa = et.IdeEmpresa,
                   IdeFilial = et.IdeFilial,
                   ClasseFinanceira = et.ClasseFinanceira,
                   IdeOdemPosicionamento = et.IdeOdemPosicionamento,
                   ModalidadeLancamento = et.ModalidadeLancamento,
                   CodigoDocumento = et.CodigoDocumento,
                   DescricaoLancamento = et.DescricaoLancamento,
                   IdeProjeto = et.IdeProjeto,
                }).ToListAsync();
        }

    }
}
