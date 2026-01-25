using Base.Application.Contracts.Notifications;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Base.Infraestructure.Notifications
{
    public class EmailService(IConfiguration configuration) : IServiceNotifications
    {
        private readonly IConfiguration configuration = configuration;

        public async Task SendEmail()
        {
            var asunto = "CORREO DE PRUEBA";
            var cuerpo = "Este es un correo de prueba";

            await SendMessage("juanmen1404@gmail.com", asunto, cuerpo);

        }

        private async Task SendMessage(string addressee, string subject, string body)
        {
            var email = configuration.GetValue<string>("EMAIL_SETTINGS:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_SETTINGS:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_SETTINGS:HOST");
            var port = configuration.GetValue<int>("EMAIL_SETTINGS:PORT");

            var smtpClient = new SmtpClient(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email, password)
            };
          
            var message = new MailMessage(email!, addressee, subject, body);
            await smtpClient.SendMailAsync(message);
        }


    }
}
