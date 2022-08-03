using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.ApplicationUserServices
{
    public interface IApplicationUserService : IGenericService<CreateApplicationUserRequestDto, UpdateApplicationUserRequestDto, GetAllApplicationUserRequestDto, GetApplicationUserRequestDto>
    {
    }
}
