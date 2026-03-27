using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Commands.Update
{
    public class UpdateSoftSkillCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public required string Description { get; set; }
        public required bool IsActive { get; set; }
    }
}
