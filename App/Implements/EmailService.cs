using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using MailKit.Security;
using ManagementSystemCV.Models;

public class EmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string htmlContent)
    {
        try
        {
            if (string.IsNullOrEmpty(toEmail))
            {
                throw new ArgumentException("El correo del destinatario no puede estar vacío", nameof(toEmail));
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            message.To.Add(new MailboxAddress("Nombre del Destinatario", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlContent
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
            throw;
        }
    }
}
