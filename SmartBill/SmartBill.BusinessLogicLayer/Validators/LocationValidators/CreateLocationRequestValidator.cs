using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.LocationValidators
{
    public class CreateLocationRequestValidator : AbstractValidator<CreateLocationRequestDto>
    {
        public CreateLocationRequestValidator()
        {
            RuleFor(x => x.City).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Region).NotEmpty().MinimumLength(3).MaximumLength(50);

            RuleFor(x => x.Street).NotEmpty().MinimumLength(3);

            RuleFor(x => x.PostalCode).NotEmpty().Length(5);

        }
    }
}