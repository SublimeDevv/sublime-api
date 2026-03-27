using Base.Application.DTOs.ProjectImages;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Queries.GetById
{
    public class GetProjectImageByIdQuery : IRequest<ProjectImageDto>
    {
        public required Guid Id { get; set; }
    }
}
