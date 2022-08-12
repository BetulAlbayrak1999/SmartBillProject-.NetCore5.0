using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Services.MailServices.SendGridMailServices;
using SmartBill.BusinessLogicLayer.Validators;
using SmartBill.BusinessLogicLayer.Validators.AuthVMValidators;
using SmartBill.BusinessLogicLayer.ViewModels.AuthVM;
using SmartBill.Entities.Domains.MSSQL;
using SmartBill.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        #region Ctor 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWT _jwt;
        private readonly IMapper _autoMapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;
        private ISendGridMailService _mailService;
        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JWT> jwt, IMapper autoMapper, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ISendGridMailService mailService)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _autoMapper = autoMapper;
            _roleManager = roleManager;
            _configuration = configuration;
            _mailService = mailService;
        }
        #endregion

        #region GetTokenAsync
        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            //validation
            var validator = new TokenRequestModelValidator();
            validator.Validate(model).throwIfValidationException();

            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "TurkishIdentity, Email or Password is incorrect";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.TurkishIdentity = user.TurkishIdentity;
            authModel.UserName = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();

            return authModel;

        }

        #endregion

        #region RegisterAsync
        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            try
            {
                //validation
                var validator = new RegisterModelValidator();
                validator.Validate(model).throwIfValidationException();

                if (await _userManager.FindByEmailAsync(model.Email) is not null)
                    return new AuthModel { Message = "Email is already registered!" };

                if (await _userManager.FindByNameAsync(model.UserName) is not null)
                    return new AuthModel { Message = "Username is already registered!" };

                //mapping between registerModel and applicationUser
                var user = _autoMapper.Map<ApplicationUser>(model);

                var result = await _userManager.CreateAsync(user, model.Password); //hashing for password

                if (!result.Succeeded)
                {
                    var errors = string.Empty;
                    foreach (var error in result.Errors)
                        errors += $"{error.Description}, ";

                    return new AuthModel { Message = errors };
                }

                //for confirming the email
                var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);
                //confirming email here should be done 
                string url = $"{_configuration["AppUrl"]}/api/Auth/ConfirmEmail?userid={user.Id}&token={validEmailToken}";

                await _mailService.SendEmailAsync(user.Email, "Confirm your email", $"<h1>Welcome to Our Project</h1>" +
                    $"<p>Please confirm your email by <a href='{url}'>Clicking here</a></p>");

                await _userManager.AddToRoleAsync(user, "User");

                var jwtSecurityToken = await CreateJwtToken(user);
                return new AuthModel //if everything is ok and IsAuthenticated is true I don't need to return messages
                {
                    Email = user.Email,
                    TurkishIdentity = user.TurkishIdentity,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = new List<string> { "User" },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    UserName = user.UserName
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region ConfirmEmailAsync
        public async Task<AuthModel> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new AuthModel
                {
                    IsAuthenticated = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new AuthModel
                {
                    Message = "Email confirmed successfully!",
                    IsAuthenticated = true,
                };

            var errors = string.Empty;
            foreach (var error in result.Errors)
                errors += $"{error.Description}, ";
            return new AuthModel
            {
                IsAuthenticated = false,
                Message = errors
            };
        }

        #endregion

        #region ForgetPasswordAsync
        public async Task<AuthModel> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AuthModel { IsAuthenticated = false, Message = "No user associated with this email" };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{_configuration["AppUrl"]}/ResetPassword?email={email}&token={validToken}";

            await _mailService.SendEmailAsync(email, "Reset Password", "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password <a href='{url}'>Click here</a></p>");
            return new AuthModel { IsAuthenticated = true, Message = "Reset Password URL has been sent to your email successfully!" };
        }

        #endregion

        #region ResetPasswordAsync
        public async Task<AuthModel> ResetPasswordAsync(ResetPasswordModel model)
        {
            //validation
            var validator = new ResetPasswordModelValidator();
            validator.Validate(model).throwIfValidationException();

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new AuthModel
                {
                    IsAuthenticated = false,
                    Message = "No user associated with this email"
                };
            if (model.NewPassword != model.ConfirmPassword)
                return new AuthModel
                {
                    IsAuthenticated = false,
                    Message = "Password doesn't match its confirmation"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);
            if (result.Succeeded)
                return new AuthModel
                {
                    IsAuthenticated = true,
                    Message = "Password has been reset successfully!!"
                };
            var errors = string.Empty;
            foreach (var error in result.Errors)
                errors += $"{error.Description}, ";
            return new AuthModel
            {
                IsAuthenticated = false,
                Message = errors
            };
        }

        #endregion

        #region CreateJwtToken
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = new List<Claim>();

            foreach (var role in roles)
                rolesClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Sub, user.TurkishIdentity),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("userid", user.Id)
            }.Union(userClaims)
             .Union(rolesClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        #endregion

    }
}
