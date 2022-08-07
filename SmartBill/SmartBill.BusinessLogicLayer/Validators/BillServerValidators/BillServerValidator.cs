using FluentValidation;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BillServerValidators
{
    public class BillServerValidator : AbstractValidator<BillServer>
    {
        public BillServerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);

        }
    }
}
