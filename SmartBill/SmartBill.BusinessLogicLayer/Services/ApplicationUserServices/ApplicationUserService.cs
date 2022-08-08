using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Dtos.RoleDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators;
using SmartBill.BusinessLogicLayer.ViewModels.ApplicationUserVM;
using SmartBill.BusinessLogicLayer.ViewModels.RoleVM;
using SmartBill.BusinessLogicLayer.ViewModels.UserRolesVM;
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
    public class ApplicationUserService: IApplicationUserService
    {
       
        private readonly IMapper _autoMapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserService(IMapper autoMapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _autoMapper = autoMapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        #region Activate
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                ApplicationUser item = await _userManager.FindByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = true;
                item.ActivatedDate = DateTime.Now;
                var IsUpdated = await _userManager.UpdateAsync(item);
                if (IsUpdated is not null)
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
                ApplicationUser item = await _userManager.FindByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = false;
                item.UnActivatedDate = DateTime.Now;
                var IsUpdated = await _userManager.UpdateAsync(item);
                if (IsUpdated is not null)
                    return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
            }
            catch (Exception ex)
            {
                return new CommandResponse { Status = false, Message = ex.Message };
            }
        }
        #endregion



       /* #region GetAll
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
        }*/


        #region GetAll
        public async Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllAsync()
        {
            try
            {
                var users = await _userManager.Users.Select(user => new GetAllApplicationUserRequestDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    TurkishIdentity = user.TurkishIdentity,
                    Email = user.Email,
                    Gender = user.Gender,
                    ProfilePicture = user.ProfilePicture,
                    Roles = _userManager.GetRolesAsync(user).Result
                }).ToListAsync();

                if (users.Any())
                    return users.DefaultIfEmpty();
                return users;
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
                var users = await _userManager.Users.Where(x=>x.IsActive==true).Select(user => new GetAllApplicationUserRequestDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    TurkishIdentity = user.TurkishIdentity,
                    Email = user.Email,
                    Gender = user.Gender,
                    ProfilePicture = user.ProfilePicture,
                    Roles = _userManager.GetRolesAsync(user).Result
                }).ToListAsync();

                if (users.Any())
                    return users.DefaultIfEmpty();
                return users;
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
                var users = await _userManager.Users.Where(x => x.IsActive == false).Select(user => new GetAllApplicationUserRequestDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    TurkishIdentity = user.TurkishIdentity,
                    Email = user.Email,
                    Gender = user.Gender,
                    ProfilePicture = user.ProfilePicture,
                    Roles = _userManager.GetRolesAsync(user).Result
                }).ToListAsync();

                if (users.Any())
                    return users.DefaultIfEmpty();
                return users;
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
                var getItem = await _userManager.FindByIdAsync(item.Id);
                if (getItem is null)
                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };

                if (item is not null && getItem is not null)
                {
                    //validation
                    var validator = new UpdateApplicationUserRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    var userWithSameEmail = await _userManager.FindByEmailAsync(item.Email);

                    if (userWithSameEmail is not null && userWithSameEmail.Id != item.Id)
                    {
                        return new CommandResponse { Status = false, Message = "this Email is already assigned to another user" };
                    }


                    var userWithSameUsername = await _userManager.FindByNameAsync(item.UserName);

                    if (userWithSameUsername is not null && userWithSameUsername.Id != item.Id)
                    {
                        return new CommandResponse { Status = false, Message = "this UserName is already assigned to another user" };
                    }

                    var userWithSameTurkishIdentity = await _userManager.FindByNameAsync(item.TurkishIdentity);

                    if (userWithSameTurkishIdentity is not null && userWithSameTurkishIdentity.Id != item.Id)
                    {
                        return new CommandResponse { Status = false, Message = "this TurkishIdentity  is already assigned to another user" };
                    }

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
                    //set lastmodifiedDate

                    var IsUpdated = await _userManager.UpdateAsync(mappedItem);
                    if (IsUpdated is not null)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }
                
            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }

        }
        #endregion


        #region CreateApplicationUserWithRoleAsync
        public async Task<CommandResponse> CreateApplicationUserWithRoleAsync(CreateApplicationUserRequestDto model)
        {
            try
            {
                if (model is not null)
                {
                    if (await _userManager.FindByEmailAsync(model.Email) is not null)
                    {
                        return new CommandResponse { Status = false, Message = "this Email is already assigned to another user" };
                    }

                    if (await _userManager.FindByNameAsync(model.UserName) is not null)
                    {
                        return new CommandResponse { Status = false, Message = "this UserName is already assigned to another user" };
                    }

                    if (await _userManager.FindByNameAsync(model.TurkishIdentity) is not null)
                    {
                        return new CommandResponse { Status = false, Message = "this TurkishIdentity is already assigned to another user" };
                    }

                    if (!model.Roles.Any(r => r.IsSelected))//if the endUser did not select any user
                    {
                        return new CommandResponse { Status = false, Message = "Please select at least one role" };
                    }

                    //validation
                    var validator = new CreateApplicationUserRequestValidator();
                    validator.Validate(model).throwIfValidationException();

                    //mapping
                    ApplicationUser mappedItem = _autoMapper.Map<ApplicationUser>(model);
                    var IsCreated = await _userManager.CreateAsync(mappedItem, model.Password);
                    if (!IsCreated.Succeeded)
                    {
                        foreach (var error in IsCreated.Errors)
                            return new CommandResponse { Status = false, Message = error.Description+ ", " };

                    }
                    await _userManager.AddToRolesAsync(mappedItem, model.Roles.Where(r => r.IsSelected).Select(r => r.Name));

                    return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }

        }

        #endregion

        #region GetApplicationUserRoles
        public async Task<UserRolesVM> GetApplicationUserRoles(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user is null)
                    return null;
                var roles = await _roleManager.Roles.ToListAsync();

                var viewModel = new UserRolesVM
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    TurkishIdentity = user.TurkishIdentity,
                    Roles = roles.Select(role => new GetRoleVM
                    {
                        Id = role.Id,
                        Name = role.Name,
                        IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                    }).ToList()
                };
                if (viewModel is not null)
                    return viewModel;
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        #endregion

        #region  GetByIdAsync
        public async Task<GetApplicationUserRequestDto> GetByIdAsync(string Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user is null)
                    return null;

                
                GetApplicationUserRequestDto result = _autoMapper.Map<ApplicationUser, GetApplicationUserRequestDto>(user);
                if (result is null)
                    return null;

                //validation
                var validator = new GetApplicationUserRequestValidator();
                validator.Validate(result).throwIfValidationException();

                return result;
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
        #endregion

        #region  GetProfileFormAsync
        public async Task<UpdateApplicationUserRequestDto> GetProfileFormAsync(string Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user is null)
                    return null;

                UpdateApplicationUserRequestDto result = _autoMapper.Map<ApplicationUser, UpdateApplicationUserRequestDto>(user);
                if (result is null)
                    return null;

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        public async Task<CreateApplicationUserRequestDto> GetExistRoles()
        {
            try
            {
                var roles = await _roleManager.Roles.Select(r => new GetRoleVM { Id = r.Id, Name = r.Name }).ToListAsync();

                var viewModel = new CreateApplicationUserRequestDto
                {
                    Roles = roles
                };

                return viewModel;
            }
            catch(Exception ex)
            {
                return null;

            }
        }
        public async Task<CommandResponse> ManageUserRoles(UserRolesVM model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (user is null)
                    return null;
                var userRoles = await _userManager.GetRolesAsync(user);

                foreach (var role in model.Roles)
                {
                    if (userRoles.Any(r => r == role.Name) && !role.IsSelected)
                        await _userManager.RemoveFromRoleAsync(user, role.Name);

                    if (!userRoles.Any(r => r == role.Name) && role.IsSelected)
                        await _userManager.AddToRoleAsync(user, role.Name);
                }

                return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
            }
            catch(Exception ex)
            {
                return new CommandResponse { Status = false, Message = ex.Message};

            }
        }
    }
}
