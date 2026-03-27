using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Commands.Update
{
    public class UpdateWorkExperienceCommand : IRequest
    {
        public required Guid Id { get; set; }
        public string? Title { get; set; }
        public required string Description { get; set; }
        public required bool IsActive { get; set; }
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
    }
}
