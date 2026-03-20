using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.DeleteRole
{
    public class DeleteRoleHandler(IRoleRepository roleRepository) : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _roleRepository = roleRepository;

        public async Task Handle(DeleteRoleCommand command)
        {
            await _roleRepository.DeleteRoleAsync(command.RoleName);
        }
    }
}
