using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostTechnologies.Commands.Remove
{
    public class RemovePostTechnologyHandler(IPostTechnologyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<RemovePostTechnologyCommand>
    {
        private readonly IPostTechnologyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(RemovePostTechnologyCommand command)
        {
            var postTechnology = await _repository.FindAsync(command.PostId, command.TechnologyId) ?? throw new NotFoundException();
            postTechnology.MarkAsDeleted();
            await _repository.UpdateAsync(postTechnology);
            await _unitOfWork.Commit();
        }
    }
}
