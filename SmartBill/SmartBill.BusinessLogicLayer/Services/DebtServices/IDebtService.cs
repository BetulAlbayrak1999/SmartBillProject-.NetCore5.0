using SmartBill.BusinessLogicLayer.Dtos.DebtDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.DebtServices
{
    public interface IDebtService : IGenericService<CreateDebtRequestDto, UpdateDebtRequestDto, GetAllDebtRequestDto, GetDebtRequestDto >
    {
    }
}
