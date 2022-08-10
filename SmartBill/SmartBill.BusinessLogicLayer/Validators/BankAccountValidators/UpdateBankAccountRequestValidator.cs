using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BankAccountValidators
{
    internal class UpdateBankAccountRequestValidator : AbstractValidator<UpdateBankAccountRequestDto>
    {
        public UpdateBankAccountRequestValidator()
        {

            RuleFor(x => x.Balance).NotEmpty().GreaterThanOrEqualTo(0);

            RuleFor(x => x.ActivatedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.UnActivatedDate).LessThanOrEqualTo(DateTime.Now);

        }
    }
}
