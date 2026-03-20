using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.RemoveRole
{
    public class RemoveRoleHandler(IUserRepository userRepository) : IRequestHandler<RemoveRoleCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Handle(RemoveRoleCommand command)
        {
            await _userRepository.RemoveRoleAsync(command.UserId, command.RoleName);
        }
    }
}
