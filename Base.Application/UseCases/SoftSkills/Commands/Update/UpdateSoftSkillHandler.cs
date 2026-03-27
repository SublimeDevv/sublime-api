using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Commands.Update
{
    public class UpdateSoftSkillHandler(ISoftSkillRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateSoftSkillCommand>
    {
        private readonly ISoftSkillRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateSoftSkillCommand command)
        {
            var softSkill = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            softSkill.Update(command.Name, command.Description, command.IsActive);
            await _repository.UpdateAsync(softSkill);
            await _unitOfWork.Commit();
        }
    }
}
