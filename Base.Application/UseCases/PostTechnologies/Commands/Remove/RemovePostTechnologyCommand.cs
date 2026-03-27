using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostTechnologies.Commands.Remove
{
    public class RemovePostTechnologyCommand : IRequest
    {
        public required Guid PostId { get; set; }
        public required Guid TechnologyId { get; set; }
    }
}
