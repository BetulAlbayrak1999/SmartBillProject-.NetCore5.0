using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.BankAccountVM
{
    public class CheckApplicationUserVM
    {
        public string Id { get; set; }
        public string TurkishIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
