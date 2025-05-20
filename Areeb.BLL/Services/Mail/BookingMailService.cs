using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areeb.BLL.Services.Mail
{
    public class BookingMailService : MailService
    {
        public BookingMailService(IConfiguration configuration) : base(configuration){}

        public async Task SendBookingConfirmationAsync(string to, string eventName, string eventDate)
        {
            var templateService = new EmailTemplateService();

            string template = templateService.LoadTemplate("BookConfirmationTemplate");

            var userName = to.Split('@')[0];

            var placeholders = new Dictionary<string, string>
            {
                { "UserName", userName },
                { "EventName", eventName },
                { "EventDate", eventDate }
            };

            string body = templateService.ReplacePlaceholders(template, placeholders);
            string subject = "Your Booking Confirmation";

            await SendEmailAsync(to, subject, body);

        }

    }
}
