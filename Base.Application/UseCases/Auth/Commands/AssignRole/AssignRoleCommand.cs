using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.AssignRole
{
    public class AssignRoleCommand : IRequest
    {
        public required string UserId { get; set; }
        public required string RoleName { get; set; }
    }
}
