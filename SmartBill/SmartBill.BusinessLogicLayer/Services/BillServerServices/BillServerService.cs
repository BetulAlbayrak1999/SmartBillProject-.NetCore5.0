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
        public Task<bool> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(CreateBillServerRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllBillServerRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllBillServerRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<GetBillServerRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateBillServerRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
