using SmartBill.BusinessLogicLayer.Configrations.Responses;
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
    public class DebtService : IDebtService
    {
        public Task<CommandResponse> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Create(CreateDebtRequestDto item)
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

        public Task<CommandResponse> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Update(UpdateDebtRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
