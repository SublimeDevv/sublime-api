namespace Base.Application.Contracts.Notifications
{
    public interface IServiceNotifications
    {
        Task SendEmail();
        Task SendPasswordResetEmailAsync(string toEmail, string resetToken);
    }
}
