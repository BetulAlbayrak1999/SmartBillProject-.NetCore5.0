using FluentValidation;
using SmartBill.BusinessLogicLayer.Dtos.CreditCardPaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.CreditCardPaymentValidators
{
    public class UpdateCreditCardPaymentRequestValidator : AbstractValidator<UpdateCreditCardPaymentRequestDto>
    {
        public UpdateCreditCardPaymentRequestValidator()
        {
            
        }
    }
}
