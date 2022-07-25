﻿using FluentValidation;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators
{
    public class BillValidator: AbstractValidator<Bill>
    {
        public BillValidator()
        {
            RuleFor(x => x.BillServerId).NotEmpty().MinimumLength(1);

            RuleFor(x => x.CustomerId).NotEmpty().MinimumLength(1);

            RuleFor(x => x.IsBillPaid).NotEmpty();

            RuleFor(x => x.PaidDate).LessThanOrEqualTo(p=> DateTime.Now).WithMessage("Paid date could not be in the future");

        }
    }
}
