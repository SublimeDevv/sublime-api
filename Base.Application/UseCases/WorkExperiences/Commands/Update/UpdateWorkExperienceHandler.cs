using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Commands.Update
{
    public class UpdateWorkExperienceHandler(IWorkExperienceRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateWorkExperienceCommand>
    {
        private readonly IWorkExperienceRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateWorkExperienceCommand command)
        {
            var workExperience = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            workExperience.Update(command.Title, command.Description, command.IsActive, command.StartDate, command.EndDate);
            await _repository.UpdateAsync(workExperience);
            await _unitOfWork.Commit();
        }
    }
}
