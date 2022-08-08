using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.ApplicationUserRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.ApplicationUserServices
{
    public class ApplicationUserService : GenericService<CreateApplicationUserRequestDto, CreateApplicationUserRequestValidator, GetApplicationUserRequestDto, GetAllApplicationUserRequestDto, ApplicationUser>, IApplicationUserService
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _autoMapper;
        public ApplicationUserService(IMapper autoMapper, IApplicationUserRepository applicationUserRepository) : base(autoMapper, applicationUserRepository)
        {
            _autoMapper = autoMapper;
            _applicationUserRepository = applicationUserRepository;
        }

        #region Activate
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                ApplicationUser item = await _applicationUserRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = true;
                item.ActivatedDate = DateTime.Now;
                bool IsUpdated = await _applicationUserRepository.UpdateAsync(item);
                if (IsUpdated)
                    return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
            }
            catch (Exception ex)
            {
                return new CommandResponse { Status = false, Message = ex.Message };
            }
        }
        #endregion


        #region UnActivate
        public async Task<CommandResponse> UnActivateAsync(string Id)
        {
            try
            {
                ApplicationUser item = await _applicationUserRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = false;
                item.UnActivatedDate = DateTime.Now;
                bool IsUpdated = await _applicationUserRepository.UpdateAsync(item);
                if (IsUpdated)
                    return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
            }
            catch (Exception ex)
            {
                return new CommandResponse { Status = false, Message = ex.Message };
            }
        }
        #endregion



        #region GetAll
        public async Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<ApplicationUser> items = await _applicationUserRepository.GetAllByAsync();
                IEnumerable<GetAllApplicationUserRequestDto> result = _autoMapper.Map<IEnumerable<ApplicationUser>, IEnumerable<GetAllApplicationUserRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region GetAllActivated
        public async Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActivatedAsync()
        {
            try
            {
                IEnumerable<ApplicationUser> items = await _applicationUserRepository.GetAllByAsync(x => x.IsActive == true);

                IEnumerable<GetAllApplicationUserRequestDto> result = _autoMapper.Map<IEnumerable<ApplicationUser>, IEnumerable<GetAllApplicationUserRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActivatedAsync()
        {
            try
            {
                IEnumerable<ApplicationUser> items = await _applicationUserRepository.GetAllByAsync(x => x.IsActive == false);

                IEnumerable<GetAllApplicationUserRequestDto> result = _autoMapper.Map<IEnumerable<ApplicationUser>, IEnumerable<GetAllApplicationUserRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion


        #region Update

        public async Task<CommandResponse> UpdateAsync(UpdateApplicationUserRequestDto item)
        {
            try
            {
                var getItem = await _applicationUserRepository.GetByIdAsync(item.Id);
                if (item is not null && getItem is not null)
                {
                    //validation
                    var validator = new UpdateApplicationUserRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //set last modify time
                    //mapping
                    ApplicationUser mappedItem = _autoMapper.Map<ApplicationUser>(item);
                    if (item.IsActive == false && getItem.IsActive == true)
                    {
                        mappedItem.UnActivatedDate = DateTime.Now;
                        mappedItem.ActivatedDate = null;
                    }
                    else if (item.IsActive == true && getItem.IsActive == false)
                    {
                        mappedItem.ActivatedDate = DateTime.Now;
                        mappedItem.UnActivatedDate = null;
                    }

                    bool IsUpdated = await _applicationUserRepository.UpdateAsync(mappedItem);
                    if (IsUpdated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }

        }
        #endregion

    }
}
