using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BillServices
{
    public class BillService //: IBillService
    {
        public Task<bool> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(CreateBillRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllBillRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllBillRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<GetBillRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateBillRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
