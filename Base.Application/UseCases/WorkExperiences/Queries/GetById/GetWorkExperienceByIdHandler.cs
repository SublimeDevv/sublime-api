using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.WorkExperiences;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Queries.GetById
{
    public class GetWorkExperienceByIdHandler(IWorkExperienceRepository repository) : IRequestHandler<GetWorkExperienceByIdQuery, WorkExperienceDto>
    {
        private readonly IWorkExperienceRepository _repository = repository;

        public async Task<WorkExperienceDto> Handle(GetWorkExperienceByIdQuery request)
        {
            var workExp = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new WorkExperienceDto
            {
                Id = workExp.Id,
                Title = workExp.Title,
                Description = workExp.Description,
                IsActive = workExp.IsActive,
                StartDate = workExp.StartDate,
                EndDate = workExp.EndDate,
                PortfolioId = workExp.PortfolioId,
                CreatedAt = workExp.CreatedAt,
                UpdatedAt = workExp.UpdatedAt
            };
        }
    }
}
