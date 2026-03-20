using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest
    {
        public required string RoleName { get; set; }
    }
}
