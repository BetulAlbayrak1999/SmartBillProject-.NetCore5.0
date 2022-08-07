using SmartBill.BusinessLogicLayer.Dtos.DebtDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.DebtServices
{
    public class DebtService //: IDebtService
    {
        public Task<bool> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(CreateDebtRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllDebtRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllDebtRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<GetDebtRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateDebtRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
