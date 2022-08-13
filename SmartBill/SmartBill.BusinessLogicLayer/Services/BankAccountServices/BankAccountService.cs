using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using SmartBill.BusinessLogicLayer.Services.ApplicationUserServices;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.BankAccountValidators;
using SmartBill.BusinessLogicLayer.ViewModels.BankAccountVM;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.BankAccountRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BankAccountServices
{
    public class BankAccountService : GenericService<BankAccount>, IBankAccountService
    {
        #region Field and Ctor
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IMapper _autoMapper;
        private readonly IApplicationUserService _applicationUserService;

        public BankAccountService(IMapper autoMapper, IBankAccountRepository BankAccountRepository, IApplicationUserService applicationUserService) : base(autoMapper, BankAccountRepository)
        {
            _autoMapper = autoMapper;
            _bankAccountRepository = BankAccountRepository;
            _applicationUserService = applicationUserService;

        }

        #endregion

        #region Activate
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                BankAccount item = await _bankAccountRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = true;
                item.ActivatedDate = DateTime.Now;
                bool IsUpdated = await _bankAccountRepository.UpdateAsync(item);
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
                BankAccount item = await _bankAccountRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = false;
                item.UnActivatedDate = DateTime.Now;
                bool IsUpdated = await _bankAccountRepository.UpdateAsync(item);
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
        public async Task<IEnumerable<GetAllBankAccountRequestDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<BankAccount> items = await _bankAccountRepository.GetAllByAsync();
                IEnumerable<GetAllBankAccountRequestDto> result = _autoMapper.Map<IEnumerable<BankAccount>, IEnumerable<GetAllBankAccountRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region GetAllActivated
        public async Task<IEnumerable<GetAllBankAccountRequestDto>> GetAllActivatedAsync()
        {
            try
            {
                IEnumerable<BankAccount> items = await _bankAccountRepository.GetAllByAsync(x => x.IsActive == true);

                IEnumerable<GetAllBankAccountRequestDto> result = _autoMapper.Map<IEnumerable<BankAccount>, IEnumerable<GetAllBankAccountRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllBankAccountRequestDto>> GetAllUnActivatedAsync()
        {
            try
            {
                IEnumerable<BankAccount> items = await _bankAccountRepository.GetAllByAsync(x => x.IsActive == false);

                IEnumerable<GetAllBankAccountRequestDto> result = _autoMapper.Map<IEnumerable<BankAccount>, IEnumerable<GetAllBankAccountRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion


        #region Update

        public async Task<CommandResponse> UpdateAsync(UpdateBankAccountRequestDto item)
        {
            try
            {
                var getItem = await _bankAccountRepository.GetByIdAsync(item.Id);
                if (item is not null && getItem is not null)
                {
                    
                    //validation
                    var validator = new UpdateBankAccountRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //set last modify time
                    //mapping
                    BankAccount mappedItem = _autoMapper.Map<BankAccount>(item);
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


                    bool IsUpdated = await _bankAccountRepository.UpdateAsync(mappedItem);
                    if (IsUpdated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        #endregion


        #region Create
        public async Task<CommandResponse> CreateAsync(CreateBankAccountRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new CreateBankAccountRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    //checking if user matches
                    var checkUser = await _applicationUserService.GetByEmailAsync(item.ApplicationUser.Email);
                    if(checkUser == null)
                        return new CommandResponse { Status = false, Message = "this User does not exist" };
                    if(item.ApplicationUser.FirstName == checkUser.FirstName && item.ApplicationUser.LastName == checkUser.LastName && item.ApplicationUser.TurkishIdentity == checkUser.TurkishIdentity && item.ApplicationUser.UserName == checkUser.UserName)
                    {
                         item.ApplicationUserId = checkUser.Id;

                        //mapping between bankAccount and dto
                        BankAccount mappedItem = _autoMapper.Map<BankAccount>(item);
                        var IsCreated = await _bankAccountRepository.CreateAsync(mappedItem);
                        if (IsCreated == true)
                            return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
                        return new CommandResponse { Status = false, Message = "This operation has not done successfully" };

                    }
                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };

                    }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        #region GetByIdAsync
        public async Task<GetBankAccountRequestDto> GetByIdAsync(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    BankAccount item = await _bankAccountRepository.GetByIdAsync(Id);
                    if (item is not null)
                    {
                        //mapping
                        GetBankAccountRequestDto mappedItem = _autoMapper.Map<GetBankAccountRequestDto>(item);
                        mappedItem.ApplicationUser = _autoMapper.Map< ApplicationUser>(await _applicationUserService.GetByIdAsync(item.ApplicationUserId));

                        return mappedItem;
                    }
                    return null;
                }

                { return null; }

            }
            catch (Exception ex) { return null; }
        }

        #endregion

        /*public async Task<IEnumerable<ApplicationUserDropDownListVM>> GetUsers()
        {
            try
            {
                var users = await _applicationUserService.GetAllActivatedAsync();
                IEnumerable<ApplicationUserDropDownListVM> userValues = _autoMapper.Map<IEnumerable<ApplicationUserDropDownListVM>>(users);

                return userValues;
            }
            catch (Exception ex) { return null; }
        }
        */
    }
}


