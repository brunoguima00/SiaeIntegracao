using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Entities;
using SiaeIntegracao.src.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public CreateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUser(UserDto user)
        {
            var contexto = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(user, contexto, validationResults, true))
            {
                var errors = string.Join("|", validationResults.Select(r => r.ErrorMessage));

                throw new Exception($"Erro de validação: {errors}");
            }

            var userExists = await _userRepository.GetUserByEmail(user.Email);

            if (userExists != null)
            {
                throw new Exception("Usuário já existe com este email.");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var newUser = new UserDto
            {
                Name = user.Name,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = hashedPassword,
                Role = user.Role,
            };

            string createUser = await _userRepository.CreateUser(newUser);
            return createUser;
        }
    }
}
