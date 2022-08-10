using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BankAccountValidators
{
    public class CreateBankAccountRequestValidator : AbstractValidator<CreateBankAccountRequestDto>
    {
        public CreateBankAccountRequestValidator()
        {
            RuleFor(x => x.BankName).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.IBAN).NotEmpty().Length(34);

            RuleFor(x => x.Balance).NotEmpty().GreaterThanOrEqualTo(0);

        }
    }
}