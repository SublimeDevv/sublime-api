using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Commands.Update
{
    public class UpdateProjectImageCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string UrlImage { get; set; }
    }
}
