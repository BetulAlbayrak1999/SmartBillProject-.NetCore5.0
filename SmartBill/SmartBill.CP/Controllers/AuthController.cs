using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartBill.BusinessLogicLayer.Abstract;
using SmartBill.BusinessLogicLayer.ViewModels;
using System.Threading.Tasks;

namespace SmartBill.CP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid) //when modelState is true, that isn't mean registeration operation will be executing!! Because in ModelState we check only the validation of values
                                     //Also if the username/email is already exit, the registration  won't be executing! (we checked this point in RegisterAsync function in AuthService class)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(model);

            //so if the username/email is already exit, IsAuthenticated will be false. Otherwise will be true. 
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(new { Username = result.UserName, Email = result.Email, Role = result.Roles, token = result.Token, ExpiresOn = result.ExpiresOn });//return as you want from these values
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.GetTokenAsync(model);

                if (result.IsAuthenticated)
                {
                    //take a look again
                    //await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " +DateTime.Now+ "</p>");
                    return Ok(result);
                }

                return BadRequest(result.Message);
            }

            return BadRequest(ModelState);
        }


    }
}
