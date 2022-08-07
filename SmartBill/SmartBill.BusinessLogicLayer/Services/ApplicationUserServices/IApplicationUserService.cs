using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.ApplicationUserServices
{
    public interface IApplicationUserService : IGenericService<CreateApplicationUserRequestDto, CreateApplicationUserRequestValidator, GetApplicationUserRequestDto, GetAllApplicationUserRequestDto, ApplicationUser>
    {
        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActivated();

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActivated();

        public Task<bool> Update(UpdateApplicationUserRequestDto item);

    }
}
