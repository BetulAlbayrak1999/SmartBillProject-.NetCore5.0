using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartBill.BusinessLogicLayer.Dtos.RoleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        
    }
}
