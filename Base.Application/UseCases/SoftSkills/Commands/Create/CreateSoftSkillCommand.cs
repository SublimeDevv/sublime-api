using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Commands.Create
{
    public class CreateSoftSkillCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public required string Description { get; set; }
        public required bool IsActive { get; set; }
        public required Guid PortfolioId { get; set; }
    }
}
