using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Commands.Delete
{
    public class DeleteSoftSkillHandler(ISoftSkillRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteSoftSkillCommand>
    {
        private readonly ISoftSkillRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteSoftSkillCommand command)
        {
            var softSkill = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            softSkill.MarkAsDeleted();
            await _repository.UpdateAsync(softSkill);
            await _unitOfWork.Commit();
        }
    }
}
