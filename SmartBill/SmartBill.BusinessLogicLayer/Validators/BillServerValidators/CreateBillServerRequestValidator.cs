using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BillServerValidators
{
    public class CreateBillServerRequestValidator : AbstractValidator<CreateBillServerRequestDto>
    {
        public CreateBillServerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);

        }
    }
    
}
