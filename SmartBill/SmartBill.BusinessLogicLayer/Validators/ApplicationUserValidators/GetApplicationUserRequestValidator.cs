using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators
{
    public class GetApplicationUserRequestValidator : AbstractValidator<GetApplicationUserRequestDto>
    {
        public GetApplicationUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.TurkishIdentity).NotEmpty().Length(11);

            RuleFor(x => x.Gender).Must(x => x.Equals("female") || x.Equals("male")).WithMessage("Only female and male gender are acceptable");

            RuleFor(x => x.Birthdate).Must(IsAgeValid).WithMessage("You must be older than 17");

            RuleFor(x => x.ProfilePicture).NotEmpty();

            RuleFor(x => x.ActivatedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.UnActivatedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.CreatedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.LastModifiedDate).LessThanOrEqualTo(DateTime.Now);

        }
        private bool IsAgeValid(DateTime Birthdate)
        {
            int currentYear = DateTime.Now.Year;
            int userYear = Birthdate.Year;

            return Math.Abs(currentYear - userYear) > 17 ? true : false;
        }
    }
}