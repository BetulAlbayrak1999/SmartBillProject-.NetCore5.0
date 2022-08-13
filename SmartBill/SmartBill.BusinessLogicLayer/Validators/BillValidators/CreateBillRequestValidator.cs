using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BillValidators
{
    public class CreateBillRequestValidator : AbstractValidator<CreateBillRequestDto>
    {
        public CreateBillRequestValidator()
        {
            RuleFor(x => x.BillServerId).NotEmpty();

            RuleFor(x => x.ApartmentId).NotEmpty();

            RuleFor(x => x.ApplicationUserId).NotEmpty();

            RuleFor(x => x.BillAmount).NotEmpty().GreaterThan(0);

        }
    }
}