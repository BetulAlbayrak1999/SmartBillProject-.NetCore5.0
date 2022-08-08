using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Dtos.RoleDto;
using SmartBill.BusinessLogicLayer.Services.ApplicationUserServices;
using SmartBill.BusinessLogicLayer.ViewModels;
using SmartBill.BusinessLogicLayer.ViewModels.RoleVM;
using SmartBill.BusinessLogicLayer.ViewModels.UserRolesVM;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationUsersController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUsersController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _applicationUserService.GetAllAsync();
                if(users == null)
                    return NotFound();

                return View(users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        public async Task<IActionResult> Update(string userId)
        {
            try
            {
                 var result = await _applicationUserService.GetProfileFormAsync(userId);
                if (result is not null)
                    return View(result);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateApplicationUserRequestDto model)
        {
            try 
            {
                var result = await _applicationUserService.UpdateAsync(model);
                if (result is not null)
                    return RedirectToAction("Index");
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<IActionResult> CreateApplicationUserWithRole()
        {
            try
            {
                var viewModel = await _applicationUserService.GetExistRoles();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApplicationUserWithRole(CreateApplicationUserRequestDto model)
        {
            if (model is null)
                return BadRequest();

            await _applicationUserService.CreateApplicationUserWithRoleAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ManageRoles(string userId)
        {
            try
            {
                var viewModel = await _applicationUserService.GetApplicationUserRoles(userId);
                if (viewModel is not null)
                    return View(viewModel);
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesVM model) 
        {
            if (model is null)
                return BadRequest();

            await _applicationUserService.ManageUserRoles(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
