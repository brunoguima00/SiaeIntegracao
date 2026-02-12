using Microsoft.EntityFrameworkCore;
using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Entities;
using SiaeIntegracao.src.Domain.Interfaces;
using SiaeIntegracao.src.Infrastructure.Data.Context;

namespace SiaeIntegracao.src.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

         
        public async Task<UserDto?> GetUserByEmail(string email)
        {
            return await _context.Usuarios
                .Where(u => u.Email == email)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Nome,
                    Email = u.Email,
                    Password = u.Senha
                })
                .FirstOrDefaultAsync();
        }

        public async Task<string> CreateUser(UserDto user)
        {
            var newUser = new Usuario
            {
                Nome = user.Name,
                Sobrenome = user.Lastname,
                Email = user.Email,
                Senha = user.Password,
                Role = user.Role
            };
            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();
            return "Usuário criado com sucesso!";
        }
    }
}
