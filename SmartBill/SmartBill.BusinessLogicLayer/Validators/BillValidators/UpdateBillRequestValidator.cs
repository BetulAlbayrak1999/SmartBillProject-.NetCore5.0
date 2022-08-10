using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BillValidators
{
    public class UpdateBillRequestValidator : AbstractValidator<UpdateBillRequestDto>
    {
        public UpdateBillRequestValidator()
        {
            RuleFor(x => x.BillServerId).NotEmpty();

            RuleFor(x => x.ApartmentId).NotEmpty();

            RuleFor(x => x.IsBillPaid).NotEmpty();

            RuleFor(x => x.BillAmount).NotEmpty().GreaterThan(0);

        }
    }
}
