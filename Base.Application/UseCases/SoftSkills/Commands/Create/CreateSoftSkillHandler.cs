using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.SoftSkills.Commands.Create
{
    public class CreateSoftSkillHandler(ISoftSkillRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateSoftSkillCommand, Guid>
    {
        private readonly ISoftSkillRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateSoftSkillCommand command)
        {
            var softSkill = new SoftSkill(command.Name, command.Description, command.IsActive, command.PortfolioId);
            await _repository.AddAsync(softSkill);
            await _unitOfWork.Commit();
            return softSkill.Id;
        }
    }
}
