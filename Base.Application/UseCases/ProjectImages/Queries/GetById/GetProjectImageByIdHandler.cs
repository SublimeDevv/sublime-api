using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.ProjectImages;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Queries.GetById
{
    public class GetProjectImageByIdHandler(IProjectImageRepository repository) : IRequestHandler<GetProjectImageByIdQuery, ProjectImageDto>
    {
        private readonly IProjectImageRepository _repository = repository;

        public async Task<ProjectImageDto> Handle(GetProjectImageByIdQuery request)
        {
            var projectImage = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new ProjectImageDto
            {
                Id = projectImage.Id,
                UrlImage = projectImage.UrlImage,
                ProjectId = projectImage.ProjectId,
                CreatedAt = projectImage.CreatedAt,
                UpdatedAt = projectImage.UpdatedAt
            };
        }
    }
}
