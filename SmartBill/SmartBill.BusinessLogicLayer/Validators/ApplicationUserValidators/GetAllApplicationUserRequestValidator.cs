using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators
{
    public class GetAllApplicationUserRequestValidator : AbstractValidator<GetAllApplicationUserRequestDto>
    {
        public GetAllApplicationUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.TurkishIdentity).NotEmpty().Length(11);

            RuleFor(x => x.Gender).Must(x => x.Equals("female") || x.Equals("male")).WithMessage("Only female and male gender are acceptable");

            RuleFor(x => x.ProfilePicture).NotNull();


        }
    }
}
