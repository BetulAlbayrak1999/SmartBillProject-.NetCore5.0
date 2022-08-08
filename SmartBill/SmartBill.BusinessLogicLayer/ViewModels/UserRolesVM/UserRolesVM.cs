using SmartBill.BusinessLogicLayer.ViewModels.RoleVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.UserRolesVM
{
    public class UserRolesVM
    {
        public string UserId { get; set; }
        public string TurkishIdentity { get; set; }
        public string UserName { get; set; }
        public List<GetRoleVM> Roles { get; set; }
    }
}
