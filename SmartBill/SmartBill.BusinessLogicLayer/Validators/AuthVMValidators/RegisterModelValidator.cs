using FluentValidation;
using SmartBill.BusinessLogicLayer.ViewModels.AuthVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.AuthVMValidators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
                RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(100);

                RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(100);

                RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).MaximumLength(50);

                RuleFor(x => x.Email).EmailAddress().NotEmpty();

                RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(16);
            
        }
    }
}
