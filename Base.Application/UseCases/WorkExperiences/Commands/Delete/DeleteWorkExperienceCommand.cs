using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Commands.Delete
{
    public class DeleteWorkExperienceCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
