using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Projects;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Projects.Queries.GetById
{
    public class GetProjectByIdHandler(IProjectRepository repository) : IRequestHandler<GetProjectByIdQuery, ProjectDto>
    {
        private readonly IProjectRepository _repository = repository;

        public async Task<ProjectDto> Handle(GetProjectByIdQuery request)
        {
            var project = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                UrlSite = project.UrlSite,
                UrlRepository = project.UrlRepository,
                IsActive = project.IsActive,
                Slug = project.Slug,
                PortfolioId = project.PortfolioId,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt
            };
        }
    }
}
