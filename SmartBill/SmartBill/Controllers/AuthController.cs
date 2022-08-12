using Microsoft.AspNetCore.Mvc;
using SmartBill.BusinessLogicLayer.Services.AuthServices;
using SmartBill.BusinessLogicLayer.ViewModels.AuthVM;
using System;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Register
        public IActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (model is null)
                return BadRequest();

            var result = await _authService.RegisterAsync(model);
            if (result.IsAuthenticated)
                return RedirectToAction("Dashboard", "Home");
            return View(result);
        }
        #endregion

        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(TokenRequestModel model)
        {
             if (model is null)
                return BadRequest();

            var result = await _authService.GetTokenAsync(model);
            if (result.IsAuthenticated == true)
                return RedirectToAction("Dashboard", "Home");
            return View(result);
        }
    }
}
