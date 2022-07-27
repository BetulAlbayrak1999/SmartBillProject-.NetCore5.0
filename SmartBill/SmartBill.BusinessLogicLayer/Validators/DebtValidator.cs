using FluentValidation;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators
{
    public class DebtValidator : AbstractValidator<Debt>
    {
        public DebtValidator()
        {
            RuleFor(x => x.BillId).NotEmpty().MinimumLength(1);

            RuleFor(x => x.IsDebtPaid).NotEmpty();

            RuleFor(x => x.DebtPaidDate).LessThanOrEqualTo(p => DateTime.Now).WithMessage("Paid date could not be in the future");
        }
    }
}