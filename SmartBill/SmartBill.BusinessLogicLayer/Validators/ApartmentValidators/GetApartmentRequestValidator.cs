using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.ApartmentValidators
{
    public class GetApartmentRequestValidator: AbstractValidator<GetApartmentRequestDto>
    {
        public GetApartmentRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.BlockNo).NotEmpty().GreaterThan(0);

            RuleFor(x => x.PersonsNumber).NotEmpty();

            RuleFor(x => x.FloorNo).NotEmpty();

            RuleFor(x => x.IsEmpty).NotEmpty();

            RuleFor(x => x.IsActive).NotEmpty();

            RuleFor(x => x.ApartmentNo).NotEmpty().GreaterThan(0);

            //RuleFor(x => x.LocationId).NotEmpty();

            RuleFor(x => x.Id).NotEmpty();
            
            RuleFor(x => x.CreatedDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ActivedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.UnActivedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.LastModifiedDate).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }
}