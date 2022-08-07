using FluentValidation;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.MessageValidators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().MinimumLength(3).MaximumLength(100);

            RuleFor(x => x.Body).NotEmpty().MinimumLength(3).MaximumLength(1000);
        }
    }
}
