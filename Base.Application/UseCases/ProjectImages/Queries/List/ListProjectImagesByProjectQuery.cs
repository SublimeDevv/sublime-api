using Base.Application.DTOs.ProjectImages;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Queries.List
{
    public class ListProjectImagesByProjectQuery : IRequest<List<ProjectImageDto>>
    {
        public required Guid ProjectId { get; set; }
    }
}
