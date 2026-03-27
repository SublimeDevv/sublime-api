using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Technologies.Commands.Create
{
    public class CreateTechnologyCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Icon { get; set; }
        public required string Color { get; set; }
    }
}
