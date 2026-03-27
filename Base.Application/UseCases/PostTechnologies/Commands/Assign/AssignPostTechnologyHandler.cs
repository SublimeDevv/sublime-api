using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.PostTechnologies.Commands.Assign
{
    public class AssignPostTechnologyHandler(IPostTechnologyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<AssignPostTechnologyCommand, Guid>
    {
        private readonly IPostTechnologyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AssignPostTechnologyCommand command)
        {
            var existing = await _repository.FindAsync(command.PostId, command.TechnologyId);
            if (existing is not null)
                throw new BusinessRuleException("Technology is already assigned to this post.");

            var postTechnology = new PostTechnology(command.PostId, command.TechnologyId);
            await _repository.AddAsync(postTechnology);
            await _unitOfWork.Commit();
            return postTechnology.Id;
        }
    }
}
