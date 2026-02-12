using SiaeIntegracao.src.Domain.Dtos;

namespace SiaeIntegracao.src.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDto?> GetUserByEmail(string email);

        public Task<string> CreateUser(UserDto user);
    }
}
