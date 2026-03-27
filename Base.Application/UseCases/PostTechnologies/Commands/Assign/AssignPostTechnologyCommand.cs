using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostTechnologies.Commands.Assign
{
    public class AssignPostTechnologyCommand : IRequest<Guid>
    {
        public required Guid PostId { get; set; }
        public required Guid TechnologyId { get; set; }
    }
}
