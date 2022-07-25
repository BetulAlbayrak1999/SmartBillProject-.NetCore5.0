using FluentValidation;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators
{
    public class ApartmentValidator : AbstractValidator<Apartment>
    {
        public ApartmentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);

            RuleFor(x => x.BlockNo).NotEmpty().GreaterThan(0);

            RuleFor(x => x.IsEmpty).NotEmpty();

            RuleFor(x => x.Area).NotEmpty().GreaterThan(0);

            RuleFor(x => x.FloorNo).NotEmpty();

            RuleFor(x => x.ApartmentNo).NotEmpty().GreaterThan(0);

            RuleFor(x => x.LocationId).NotEmpty().MinimumLength(1);
        }
    }
}
