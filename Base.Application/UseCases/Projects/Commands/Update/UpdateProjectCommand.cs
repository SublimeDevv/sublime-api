using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Projects.Commands.Update
{
    public class UpdateProjectCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? UrlSite { get; set; }
        public string? UrlRepository { get; set; }
        public required bool IsActive { get; set; }
        public required string Slug { get; set; }
    }
}
