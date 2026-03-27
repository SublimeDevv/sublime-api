using Base.Application.DTOs.Projects;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Projects.Queries.GetById
{
    public class GetProjectByIdQuery : IRequest<ProjectDto>
    {
        public required Guid Id { get; set; }
    }
}
