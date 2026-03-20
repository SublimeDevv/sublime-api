using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest
    {
        public required string RoleName { get; set; }
    }
}
