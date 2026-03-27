using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Technologies.Commands.Delete
{
    public class DeleteTechnologyCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
