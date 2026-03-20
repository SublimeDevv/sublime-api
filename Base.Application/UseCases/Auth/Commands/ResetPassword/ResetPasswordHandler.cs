using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.ResetPassword
{
    public class ResetPasswordHandler(
        IUserRepository userRepository) : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Handle(ResetPasswordCommand command)
        {
            var user = await _userRepository.FindByEmailAsync(command.Email)
                ?? throw new NotFoundException();

            await _userRepository.ResetPasswordAsync(user.Id, command.Token, command.NewPassword);
        }
    }
}
