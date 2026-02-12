using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;

namespace SiaeIntegracao.src.Infrastructure.Repositories
{
    public class DocumentsTypeRepository : IDocumentsType
    {
        private readonly AppDbContext _context;

        public DocumentsTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentsTypeDto>> GetAllDocumentsType()
        {
            return await _context.PfTipoDocs
                .Select(dt => new DocumentsTypeDto
                {
                    Id = dt.Id,
                    CodDocumento = dt.CodDocumento,
                    NomeDocumento = dt.NomeDocumento,
                    TipoDocumento = dt.TipoDocumento,
                    Contabiliza = dt.Contabiliza,
                    DataCriacao = dt.DataCriacao
                }).ToListAsync();

        }
    }
}
