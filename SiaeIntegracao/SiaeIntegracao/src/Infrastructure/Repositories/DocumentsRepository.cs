using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Entities;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;

namespace SiaeIntegracao.src.Infrastructure.Repositories
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly AppDbContext _context;

        public DocumentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateDocument(DocumentsDto document)
        {
            var newDocument = new PfDocumento
            {
                Projeto = document.Projeto,
                DataPc = document.DataPc,
                CodDocumento = document.CodDocumento,
                Valor = document.Valor,
                Status = document.Status,
                DataDeposito = document.DataDeposito,
                CodAgente = document.CodAgente,
                IdTipoDoc = document.IdTipoDoc

            };

            await _context.PfDocumentos.AddAsync(newDocument);
            await _context.SaveChangesAsync();

            return "Document created successfully";
        }


        public async Task<List<DocumentsDto>> GetDocumentsByDate(string projeto, DateOnly date)
        {
            return await (from d in _context.PfDocumentos
                          join t in _context.PfTipoDocs on d.IdTipoDoc equals t.Id
                          where d.DataPc == date && d.Projeto == projeto
                          select new DocumentsDto
                          {
                              Id = d.Id,
                              Projeto = d.Projeto,
                              CodDocumento = d.CodDocumento,
                              // Aqui vem o dado da tabela de Tipos!
                              NomeDocumento = t.NomeDocumento,
                              Valor = d.Valor,
                              Status = d.Status
                          }).ToListAsync();
        }

        public async Task<bool> DeleteDocumentById(long id)
        {
            var document = await _context.PfDocumentos.FindAsync(id);
            if (document == null)
            {
                return false; // Document not found
            }
            _context.PfDocumentos.Remove(document);
            await _context.SaveChangesAsync();
            return true; // Document deleted successfully
        }

        public async Task<int> UpdateDocumentsStatusByDate(DateOnly datePc, string projeto, string status)
        {
            // Executa o UPDATE direto no SQL Server em uma única linha
            var linhasAfetadas = await _context.PfDocumentos
                .Where(c => c.DataPc == datePc && c.Projeto == projeto)
                .ExecuteUpdateAsync(s => s.SetProperty(c => c.Status, status));

            return linhasAfetadas;
        }
    }
}