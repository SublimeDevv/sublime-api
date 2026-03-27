using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Commands.Delete
{
    public class DeleteSoftSkillCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
