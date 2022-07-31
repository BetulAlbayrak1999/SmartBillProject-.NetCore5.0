using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBill.BusinessLogicLayer.ViewModels.Role;
using SmartBill.BusinessLogicLayer.ViewModels.UserRoles;
using SmartBill.BusinessLogicLayer.ViewModels.Users;
using SmartBill.Entities.Domains;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    [Authorize(Roles = "User")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                TurkishIdentity = user.TurkishIdentity,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return NotFound();
            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                TurkishIdentity = user.TurkishIdentity,
                Roles = roles.Select(role => new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model) 
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
                return NotFound();
            var userRoles = await _userManager.GetRolesAsync(user);
            
            foreach(var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.Name) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.Name);

                if(!userRoles.Any(r=> r == role.Name) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.Name);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
