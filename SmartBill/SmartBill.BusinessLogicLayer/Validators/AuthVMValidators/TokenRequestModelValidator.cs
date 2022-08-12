using FluentValidation;
using SmartBill.BusinessLogicLayer.ViewModels.AuthVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.AuthVMValidators
{
    public class TokenRequestModelValidator: AbstractValidator<TokenRequestModel>
    {
        public TokenRequestModelValidator() {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(16);
        }
    }
}
