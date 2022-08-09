using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BillServerValidators
{
    public class UpdateBillServerRequestValidator : AbstractValidator<UpdateBillServerRequestDto>
    {
        public UpdateBillServerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.UnActivatedDate).LessThanOrEqualTo(DateTime.Now);
            
            RuleFor(x => x.ActivatedDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.LastModifiedDate).LessThanOrEqualTo(DateTime.Now);

        }
    }
}
