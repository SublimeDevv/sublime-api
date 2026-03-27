using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Technologies;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Technologies.Queries.GetById
{
    public class GetTechnologyByIdHandler(ITechnologyRepository repository) : IRequestHandler<GetTechnologyByIdQuery, TechnologyDto>
    {
        private readonly ITechnologyRepository _repository = repository;

        public async Task<TechnologyDto> Handle(GetTechnologyByIdQuery request)
        {
            var technology = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new TechnologyDto
            {
                Id = technology.Id,
                Name = technology.Name,
                Description = technology.Description,
                Icon = technology.Icon,
                Color = technology.Color,
                CreatedAt = technology.CreatedAt,
                UpdatedAt = technology.UpdatedAt
            };
        }
    }
}
