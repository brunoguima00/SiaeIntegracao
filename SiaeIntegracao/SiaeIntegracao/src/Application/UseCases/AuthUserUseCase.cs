using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;
using System.Diagnostics;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class AuthUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public AuthUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> AuthUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
