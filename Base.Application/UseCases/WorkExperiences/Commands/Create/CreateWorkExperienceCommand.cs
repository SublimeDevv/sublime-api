using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Commands.Create
{
    public class CreateWorkExperienceCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public required string Description { get; set; }
        public required bool IsActive { get; set; }
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        public required Guid PortfolioId { get; set; }
    }
}
