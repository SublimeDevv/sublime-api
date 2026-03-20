using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.AssignRole
{
    public class AssignRoleHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository) : IRequestHandler<AssignRoleCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;

        public async Task Handle(AssignRoleCommand command)
        {
            if (!await _roleRepository.RoleExistsAsync(command.RoleName))
                throw new BusinessRuleException($"El rol '{command.RoleName}' no existe.");

            await _userRepository.AssignRoleAsync(command.UserId, command.RoleName);
        }
    }
}
