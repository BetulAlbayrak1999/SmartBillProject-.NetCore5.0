using FluentValidation;
using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Validators.BaseEntityValidators
{
    public class BaseEntityValidator : AbstractValidator<BaseEntity>
    {
        public BaseEntityValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().MinimumLength(1);

            RuleFor(x => x.CreatedDate).NotNull().LessThanOrEqualTo(p => DateTime.Now).WithMessage("Date could not be in the future");

            RuleFor(x => x.LastModifiedDate).NotNull().LessThanOrEqualTo(p => DateTime.Now).WithMessage("This date could not be in the future");

            RuleFor(x => x.UnActivedDate).LessThanOrEqualTo(p => DateTime.Now).WithMessage("This date could not be in the future");

            RuleFor(x => x.ActivedDate).LessThanOrEqualTo(p => DateTime.Now).WithMessage("This date could not be in the future");

            RuleFor(x => x.IsActive).NotNull();
        }
    }
}