using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.BackgroundJobs.HangfireJobs.GenericJobs
{
    public interface IHangfireJob
    {
        //void DelayedJob(int userId, string userName, TimeSpan timeSpan);
        Task<bool> FireAndForget(string applicationUser, string context);
        Task<bool> ReccuringJob();
    }
}
