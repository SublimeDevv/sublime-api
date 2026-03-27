using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.SocialsMedia.Commands.Create
{
    public class CreateSocialMediaHandler(ISocialMediaRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateSocialMediaCommand, Guid>
    {
        private readonly ISocialMediaRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateSocialMediaCommand command)
        {
            var socialMedia = new SocialMedia(command.Name, command.Icon, command.Color, command.Url, command.PortfolioId);
            await _repository.AddAsync(socialMedia);
            await _unitOfWork.Commit();
            return socialMedia.Id;
        }
    }
}
