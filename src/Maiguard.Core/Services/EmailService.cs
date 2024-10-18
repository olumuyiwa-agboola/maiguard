using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.AppSettings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Services
{
    /// <summary>
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly EmailClientConfiguration _emailSettings;

        /// <summary>
        /// </summary>
        /// <param name="emailClientConfiguration"></param>
        public EmailService(IOptions<EmailClientConfiguration> emailClientConfiguration)
        {
            _emailSettings = emailClientConfiguration.Value;
        }

        /// <summary>
        /// </summary>
        /// <param name="invitationCode"></param>
        /// <param name="recipient"></param>
        /// <param name="recipientName"></param>
        /// <returns></returns>
        public async Task SendInvitationViaEmail(string invitationCode, string recipient, string recipientName)
        {
            string invitationCodeEmailBody = @$"
                            Dear {recipientName},

                            Your invitation code is {invitationCode}.";

            MimeMessage email = new();
            email.From.Add(MailboxAddress.Parse(_emailSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(recipient));
            email.Subject = _emailSettings.InvitationCodeEmailSubject;
            email.Body = new TextPart(TextFormat.Html) { Text = invitationCodeEmailBody };

            using SmtpClient smtpClient = new();
            smtpClient.Connect(_emailSettings.SMTPHost, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtpClient.Authenticate(_emailSettings.Username, _emailSettings.Password);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
