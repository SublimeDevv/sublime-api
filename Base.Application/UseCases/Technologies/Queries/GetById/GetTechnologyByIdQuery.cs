using Base.Application.DTOs.Technologies;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Technologies.Queries.GetById
{
    public class GetTechnologyByIdQuery : IRequest<TechnologyDto>
    {
        public required Guid Id { get; set; }
    }
}
