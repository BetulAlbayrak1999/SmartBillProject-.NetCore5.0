using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.AuthVM
{
    public class RegisterModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string TurkishIdentity { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
