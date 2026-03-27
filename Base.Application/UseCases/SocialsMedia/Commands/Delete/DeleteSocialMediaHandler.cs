using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Commands.Delete
{
    public class DeleteSocialMediaHandler(ISocialMediaRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteSocialMediaCommand command)
        {
            var socialMedia = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            socialMedia.MarkAsDeleted();
            await _repository.UpdateAsync(socialMedia);
            await _unitOfWork.Commit();
        }
    }
}
