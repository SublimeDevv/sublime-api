using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.SoftSkills;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Queries.GetById
{
    public class GetSoftSkillByIdHandler(ISoftSkillRepository repository) : IRequestHandler<GetSoftSkillByIdQuery, SoftSkillDto>
    {
        private readonly ISoftSkillRepository _repository = repository;

        public async Task<SoftSkillDto> Handle(GetSoftSkillByIdQuery request)
        {
            var softSkill = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new SoftSkillDto
            {
                Id = softSkill.Id,
                Name = softSkill.Name,
                Description = softSkill.Description,
                IsActive = softSkill.IsActive,
                PortfolioId = softSkill.PortfolioId,
                CreatedAt = softSkill.CreatedAt,
                UpdatedAt = softSkill.UpdatedAt
            };
        }
    }
}
