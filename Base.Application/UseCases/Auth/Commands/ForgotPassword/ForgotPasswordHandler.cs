using Base.Application.Contracts.Notifications;
using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordHandler(
        IUserRepository userRepository,
        IServiceNotifications notifications) : IRequestHandler<ForgotPasswordCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IServiceNotifications _notifications = notifications;

        public async Task Handle(ForgotPasswordCommand command)
        {
            var user = await _userRepository.FindByEmailAsync(command.Email);
            if (user is null) return;

            var token = await _userRepository.GeneratePasswordResetTokenAsync(user.Id);
            await _notifications.SendPasswordResetEmailAsync(command.Email, token);
        }
    }
}
