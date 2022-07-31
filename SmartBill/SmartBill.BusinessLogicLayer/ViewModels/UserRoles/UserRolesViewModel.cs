using SmartBill.BusinessLogicLayer.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.UserRoles
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string TurkishIdentity { get; set; }
        public string UserName { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
