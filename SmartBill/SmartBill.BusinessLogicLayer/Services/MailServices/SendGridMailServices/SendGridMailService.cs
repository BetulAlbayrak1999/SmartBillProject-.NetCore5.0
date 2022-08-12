using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.MailServices.SendGridMailServices
{
    public class SendGridMailService : ISendGridMailService
    {
        private IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["MailSetting:SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_configuration["MailSetting:From"], "SmartBill Team:)");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
