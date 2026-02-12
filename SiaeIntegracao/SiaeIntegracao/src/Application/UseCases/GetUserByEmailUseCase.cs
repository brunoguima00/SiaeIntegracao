using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class GetUserByEmailUseCase
    {
        private readonly IUserRepository userRepository;

        public GetUserByEmailUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<UserDto?> Execute(string email)
        {
            return await userRepository.GetUserByEmail(email);
        }


    }
}
