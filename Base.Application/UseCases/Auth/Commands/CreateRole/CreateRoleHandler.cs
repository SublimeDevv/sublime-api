using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.CreateRole
{
    public class CreateRoleHandler(IRoleRepository roleRepository) : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository = roleRepository;

        public async Task Handle(CreateRoleCommand command)
        {
            await _roleRepository.CreateRoleAsync(command.RoleName);
        }
    }
}
