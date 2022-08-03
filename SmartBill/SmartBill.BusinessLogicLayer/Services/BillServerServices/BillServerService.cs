using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BillServerServices
{
    public class BillServerService : IBillServerService
    {
        public Task<CommandResponse> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Create(CreateBillServerRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllBillServerRequestDto>> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllBillServerRequestDto>> GetAllUnActive()
        {
            throw new NotImplementedException();
        }

        public Task<GetBillServerRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Update(UpdateBillServerRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
