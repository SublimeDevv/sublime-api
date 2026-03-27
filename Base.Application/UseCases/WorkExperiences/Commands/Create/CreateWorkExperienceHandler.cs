using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.WorkExperiences.Commands.Create
{
    public class CreateWorkExperienceHandler(IWorkExperienceRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateWorkExperienceCommand, Guid>
    {
        private readonly IWorkExperienceRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateWorkExperienceCommand command)
        {
            var workExperience = new WorkExperience(command.Title, command.Description, command.IsActive, command.StartDate, command.EndDate, command.PortfolioId);
            await _repository.AddAsync(workExperience);
            await _unitOfWork.Commit();
            return workExperience.Id;
        }
    }
}
