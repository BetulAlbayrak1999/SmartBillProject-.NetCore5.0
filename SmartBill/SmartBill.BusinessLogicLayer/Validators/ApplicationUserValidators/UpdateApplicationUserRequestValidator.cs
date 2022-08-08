using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators
{
    public class UpdateApplicationUserRequestValidator : AbstractValidator<UpdateApplicationUserRequestDto>
    {
        public UpdateApplicationUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.VehicleNo).MinimumLength(5);

            RuleFor(x => x.ActivatedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.UnActivatedDate).LessThanOrEqualTo(DateTime.Now);

        }
    }
}

