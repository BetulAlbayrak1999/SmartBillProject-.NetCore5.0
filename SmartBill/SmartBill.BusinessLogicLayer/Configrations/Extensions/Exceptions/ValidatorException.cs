using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions
{
    public static class ValidatorException
    {
        public static void throwIfValidationException(this FluentValidation.Results.ValidationResult validationResult)
        {
            if (validationResult.IsValid)
                return;

            var messages = string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(messages);
        }
    }
}

