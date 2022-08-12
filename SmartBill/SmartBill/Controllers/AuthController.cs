using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBill.BusinessLogicLayer.Services.AuthServices;
using SmartBill.BusinessLogicLayer.ViewModels.AuthVM;
using System;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
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
                return RedirectToAction("Welcome", "Home");
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
                return RedirectToAction("Welcome", "Home");
            return View(result);
        }
    }
}
