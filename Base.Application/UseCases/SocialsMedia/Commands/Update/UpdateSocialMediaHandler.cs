using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Commands.Update
{
    public class UpdateSocialMediaHandler(ISocialMediaRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateSocialMediaCommand command)
        {
            var socialMedia = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            socialMedia.Update(command.Name, command.Icon, command.Color, command.Url);
            await _repository.UpdateAsync(socialMedia);
            await _unitOfWork.Commit();
        }
    }
}
