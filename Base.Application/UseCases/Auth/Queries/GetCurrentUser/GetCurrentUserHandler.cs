using Base.Application.Contracts.Repositories.Auth;
using Base.Application.DTOs.Auth;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Queries.GetCurrentUser
{
    public class GetCurrentUserHandler(IUserRepository userRepository) : IRequestHandler<GetCurrentUserQuery, UserDetailDto>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDetailDto> Handle(GetCurrentUserQuery query)
        {
            return await _userRepository.FindByIdAsync(query.UserId)
                ?? throw new NotFoundException();
        }
    }
}
