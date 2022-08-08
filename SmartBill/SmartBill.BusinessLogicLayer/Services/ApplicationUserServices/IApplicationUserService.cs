using SmartBill.BusinessLogicLayer.Configrations.Responses;
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
        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActivatedAsync();

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActivatedAsync();

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllAsync();

        public Task<CommandResponse> UpdateAsync(UpdateApplicationUserRequestDto item);

        public Task<CommandResponse> ActivateAsync(string Id);

        public Task<CommandResponse> UnActivateAsync(string Id);

    }
}