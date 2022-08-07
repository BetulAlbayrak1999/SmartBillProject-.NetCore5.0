using FluentValidation;
using SmartBill.Entities.Domains;
using SmartBill.Entities.Domains.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators
{
    public class CreditCardValidator// : AbstractValidator<CreditCard>
    {
        
    }
}
/*
 * public CreditCardValidator()
        {
            //RuleFor(x => x.CustomerId).NotEmpty().NotNull().MinimumLength(1);

            RuleFor(x => x.BankId).NotEmpty().NotNull().MinimumLength(1);

            RuleFor(x => x.ExpireTime).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
        }
 */