using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels
{
    public class AuthModel
    {
        public string Message { get; set; }

        public bool IsAuthenticated { get; set; }=false;

        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public string Token { get; set; }

        public string UserName { get; set; }
        
        public DateTime ExpiresOn { get; set; }
    }
}
