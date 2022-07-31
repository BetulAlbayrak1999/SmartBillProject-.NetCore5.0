using FluentValidation;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.CityId).NotEmpty().MinimumLength(1);

            RuleFor(x => x.Street).NotEmpty().MinimumLength(3);

            RuleFor(x => x.PostalCode).NotEmpty().Length(5);

        }
    }
}
