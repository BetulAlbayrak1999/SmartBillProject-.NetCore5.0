using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class ApplicationUsersController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly ILogger<ApplicationUsersController> _logger;

        public ApplicationUsersController(IApplicationUserService applicationUserService, ILogger<ApplicationUsersController> logger)
        {
            _applicationUserService = applicationUserService;
            _logger = logger;
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
                {
                    var viewModel = new UpdateApplicationUserRequestDto
                    {
                        Id = result.Id,
                        UserName = result.UserName, 
                        FirstName = result.FirstName,
                        LastName = result.LastName, 
                        Email = result.Email,
                        VehicleNo = result.VehicleNo,
                        TurkishIdentity = result.TurkishIdentity,
                        IsActive = result.IsActive,
                        ProfilePicture = result.ProfilePicture,
                    };
                    return View(viewModel);
                }
                    
                return null;
            }
            catch (Exception ex)
            {
                ViewBag.ex = ex.Message;
                return View();
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
                return View(model);
            }
            catch(Exception ex)
            {
                ViewBag.ex = ex.Message;
                return View(model);
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

            var result = await _applicationUserService.CreateApplicationUserWithRoleAsync(model);
            if(result is not null)
                return RedirectToAction(nameof(Index));
            return View(result);
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
