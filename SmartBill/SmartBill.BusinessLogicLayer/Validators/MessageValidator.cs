using FluentValidation;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().MinimumLength(3);

            RuleFor(x => x.Body).NotEmpty().MaximumLength(500);
        }
    }
}
