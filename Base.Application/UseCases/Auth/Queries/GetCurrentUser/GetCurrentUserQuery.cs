using Base.Application.DTOs.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Queries.GetCurrentUser
{
    public class GetCurrentUserQuery : IRequest<UserDetailDto>
    {
        public required string UserId { get; set; }
    }
}
