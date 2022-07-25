using FluentValidation;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators
{
    public class BillServerValidator: AbstractValidator<BillServer>
    {
        public BillServerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);

        }
    }
}
