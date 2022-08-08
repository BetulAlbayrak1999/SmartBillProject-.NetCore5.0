using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.RoleDto
{
    public class GetRoleRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
