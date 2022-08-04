using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.ApartmentValidators
{
    public class CreateApartmentRequestValidator: AbstractValidator<CreateApartmentRequestDto>
    {
        public CreateApartmentRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.BlockNo).NotEmpty().GreaterThan(0);

            RuleFor(x => x.PersonsNumber).NotEmpty();

            RuleFor(x => x.FloorNo).NotEmpty();

            RuleFor(x => x.ApartmentNo).NotEmpty().GreaterThan(0);

            //RuleFor(x => x.LocationId).NotEmpty().MinimumLength(1);
        }
    }
}