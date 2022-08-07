using FluentValidation;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BankValidators
{
    public class BankValidator : AbstractValidator<BankAccount>
    {
        public BankValidator()
        {
        }
    }
}
