using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace Services.Mail
{
    public abstract class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:MailUser"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

           using var smtp = new SmtpClient();
           await smtp.ConnectAsync(_configuration["MailSettings:MailHost"], int.Parse(_configuration["MailSettings:MailPort"]), SecureSocketOptions.StartTls);
           await smtp.AuthenticateAsync(_configuration["MailSettings:MailUser"], _configuration["MailSettings:MailPassword"]);
           await smtp.SendAsync(email);
           await smtp.DisconnectAsync(true);
        }


    }
}
