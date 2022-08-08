using FluentValidation;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.LocationValidators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.CityName).NotEmpty().MinimumLength(3).MaximumLength(50);

            RuleFor(x => x.Street).NotEmpty().MinimumLength(3);

            RuleFor(x => x.PostalCode).NotEmpty().Length(5);

        }
    }
}
