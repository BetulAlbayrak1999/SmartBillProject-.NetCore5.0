using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators
{
    public class CreateApplicationUserRequestValidator : AbstractValidator<CreateApplicationUserRequestDto>
    {
        public CreateApplicationUserRequestValidator ()
        {
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.TurkishIdentity).NotEmpty().Length(11);

            RuleFor(x => x.PhoneNumber).NotEmpty().Length(11);

            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Gender).Must(x => x.Equals("female") || x.Equals("male")).WithMessage("Only female and male gender are acceptable");

            RuleFor(x => x.Birthdate).Must(IsAgeValid).WithMessage("You must be older than 17");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

            RuleFor(x => x.ConfirmPassword == x.Password);
        }
        private bool IsAgeValid(DateTime Birthdate)
        {
            int currentYear = DateTime.Now.Year;
            int userYear = Birthdate.Year;

            return Math.Abs(currentYear - userYear) > 17 ? true : false;
        }
    }
}

