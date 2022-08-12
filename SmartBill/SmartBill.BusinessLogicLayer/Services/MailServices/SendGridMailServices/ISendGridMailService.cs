using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.MailServices.SendGridMailServices
{
    public interface ISendGridMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
