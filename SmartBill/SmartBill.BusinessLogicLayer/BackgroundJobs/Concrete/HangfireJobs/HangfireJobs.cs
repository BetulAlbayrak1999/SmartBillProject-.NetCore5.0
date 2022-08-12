using SmartBill.BusinessLogicLayer.BackgroundJobs.Abstract;
using SmartBill.BusinessLogicLayer.Services.MailServices.SendGridMailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.BackgroundJobs.Concrete.HangfireJobs
{
    public class HangfireJobs : IJobs
    {
        private ISendGridMailService _sendGridMailService;

        public HangfireJobs(ISendGridMailService sendGridMailService)
        {
            _sendGridMailService = sendGridMailService;
        }

        public void DelayedJobEmail(string toEmail, string subject, string content, TimeSpan timeSpan)
        {
            Hangfire.BackgroundJob.Schedule(() => _sendGridMailService.SendEmailAsync(toEmail, subject, content), timeSpan);
        }

        public void FireAndForgetEmail(string toEmail, string subject, string content)
        {
            Hangfire.BackgroundJob.Enqueue(() => _sendGridMailService.SendEmailAsync(toEmail, subject, content));
        }

        public void ReccuringJob()
        {
            //Console.WriteLine($"Recurring job örneği {DateTime.Now}");
        }
    }
}
