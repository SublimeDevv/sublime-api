using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.RemoveRole
{
    public class RemoveRoleCommand : IRequest
    {
        public required string UserId { get; set; }
        public required string RoleName { get; set; }
    }
}
