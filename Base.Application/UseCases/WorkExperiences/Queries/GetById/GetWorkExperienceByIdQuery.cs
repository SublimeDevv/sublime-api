using Base.Application.DTOs.WorkExperiences;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Queries.GetById
{
    public class GetWorkExperienceByIdQuery : IRequest<WorkExperienceDto>
    {
        public required Guid Id { get; set; }
    }
}
