using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.ApartmentValidators
{
    public class UpdateApartmentRequestValidator : AbstractValidator<UpdateApartmentRequestDto> 
    {
        public UpdateApartmentRequestValidator()
        {
            RuleFor(x => x.PersonsNumber).NotEmpty();

            RuleFor(x => x.UnActivedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ActivedDate).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
