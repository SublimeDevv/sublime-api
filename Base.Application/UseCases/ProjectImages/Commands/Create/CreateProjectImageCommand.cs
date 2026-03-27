using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Commands.Create
{
    public class CreateProjectImageCommand : IRequest<Guid>
    {
        public required string UrlImage { get; set; }
        public required Guid ProjectId { get; set; }
    }
}
