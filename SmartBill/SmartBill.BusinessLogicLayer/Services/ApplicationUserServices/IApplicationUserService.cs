using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators;
using SmartBill.BusinessLogicLayer.ViewModels.ApplicationUserVM;
using SmartBill.BusinessLogicLayer.ViewModels.BankAccountVM;
using SmartBill.BusinessLogicLayer.ViewModels.UserRolesVM;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.ApplicationUserServices
{
    public interface IApplicationUserService 
    {
        public Task<UserRolesVM> GetApplicationUserRoles(string userId);
        public Task<CommandResponse> ManageUserRoles(UserRolesVM model);
        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActivatedAsync();

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActivatedAsync();

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllAsync();

        public Task<GetApplicationUserRequestDto> GetByIdAsync(string Id);

        public Task<UpdateApplicationUserRequestDto> GetProfileFormAsync(string Id);

        public Task<CommandResponse> UpdateAsync(UpdateApplicationUserRequestDto item);

        public Task<CommandResponse> ActivateAsync(string Id);

        public Task<CommandResponse> UnActivateAsync(string Id);

        public Task<CommandResponse> CreateApplicationUserWithRoleAsync(CreateApplicationUserRequestDto model);

        public Task<CreateApplicationUserRequestDto> GetExistRoles();
        public Task<CheckApplicationUserVM> GetByEmailAsync(string email);

    }
}