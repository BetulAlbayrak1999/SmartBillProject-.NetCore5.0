using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.BackgroundJobs.Abstract
{
    public interface IJobs
    {
        void DelayedJobEmail(string toEmail, string subject, string content, TimeSpan timeSpan);
        void FireAndForgetEmail(string toEmail, string subject, string content);
        void ReccuringJob();
    }
}
