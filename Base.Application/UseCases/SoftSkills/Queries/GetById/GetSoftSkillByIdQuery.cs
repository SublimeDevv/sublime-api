using Base.Application.DTOs.SoftSkills;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Queries.GetById
{
    public class GetSoftSkillByIdQuery : IRequest<SoftSkillDto>
    {
        public required Guid Id { get; set; }
    }
}
