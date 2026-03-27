using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.ProjectImages;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Queries.List
{
    public class ListProjectImagesByProjectHandler(IProjectImageRepository repository) : IRequestHandler<ListProjectImagesByProjectQuery, List<ProjectImageDto>>
    {
        private readonly IProjectImageRepository _repository = repository;

        public async Task<List<ProjectImageDto>> Handle(ListProjectImagesByProjectQuery request)
        {
            var items = await _repository.ListByProjectAsync(request.ProjectId);

            return items.Select(p => new ProjectImageDto
            {
                Id = p.Id,
                UrlImage = p.UrlImage,
                ProjectId = p.ProjectId,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }
    }
}
