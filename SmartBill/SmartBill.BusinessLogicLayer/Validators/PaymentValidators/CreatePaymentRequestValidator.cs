using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.PaymentValidators
{
    public class CreatePaymentRequestValidator: AbstractValidator<CreatePaymentRequestDto>
    {
    }
}
