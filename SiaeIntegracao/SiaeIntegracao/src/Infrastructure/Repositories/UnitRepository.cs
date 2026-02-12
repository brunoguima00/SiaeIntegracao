using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;

namespace SiaeIntegracao.src.Infrastructure.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly AppDbContext _context;

        public UnitRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<FilialDto>> GetAllowedUnits(int userId)
        {
            return await (from p in _context.Permissoes
                          join f in _context.CgFilials on p.Projeto equals f.IdeProjeto
                          where p.IdUsuario == userId  // Filtramos apenas pelo USUÁRIO
                          select new FilialDto
                          {
                              Projeto = p.Projeto, // Aqui você descobre qual é o projeto (SIAE, etc)                            
                              NomeFilial = f.RazaoReduzidaFilial
                          }).ToListAsync();
        }

    }
}
