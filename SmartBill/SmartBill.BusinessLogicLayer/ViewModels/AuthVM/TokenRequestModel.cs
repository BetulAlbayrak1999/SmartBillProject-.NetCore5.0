using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.AuthVM
{
    public class TokenRequestModel
    {
        public string Email { get; set; }
        public string TurkishIdentity { get; set; }

        public string Password { get; set; }
    }
}
