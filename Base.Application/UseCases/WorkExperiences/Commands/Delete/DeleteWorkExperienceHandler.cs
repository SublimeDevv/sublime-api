using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Commands.Delete
{
    public class DeleteWorkExperienceHandler(IWorkExperienceRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteWorkExperienceCommand>
    {
        private readonly IWorkExperienceRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteWorkExperienceCommand command)
        {
            var workExperience = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            workExperience.MarkAsDeleted();
            await _repository.UpdateAsync(workExperience);
            await _unitOfWork.Commit();
        }
    }
}
