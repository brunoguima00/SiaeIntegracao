using SiaeIntegracao.src.Domain.Dtos;
using SiaeIntegracao.src.Domain.Interfaces;

namespace SiaeIntegracao.src.Application.UseCases
{
    public class GetAllowedUnitsUseCase
    {
        private readonly IUnitRepository _unitRepository;
        public GetAllowedUnitsUseCase(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<List<FilialDto>> Execute(int userId)
        {
            if(userId <= 0)
                throw new ArgumentException("User ID must be greater than zero.", nameof(userId));

            return await _unitRepository.GetAllowedUnits(userId);
        }
    }
}