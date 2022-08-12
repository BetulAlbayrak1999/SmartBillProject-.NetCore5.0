using SmartBill.BusinessLogicLayer.ViewModels.AuthVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.AuthServices
{
    public interface IAuthService
    {
        Task<RegisterModel> RegisterAsync(RegisterModel model);

        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<AuthModel> ConfirmEmailAsync(string userId, string token);

        Task<AuthModel> ForgetPasswordAsync(string email);

        Task<AuthModel> ResetPasswordAsync(ResetPasswordModel model);
    }
}
