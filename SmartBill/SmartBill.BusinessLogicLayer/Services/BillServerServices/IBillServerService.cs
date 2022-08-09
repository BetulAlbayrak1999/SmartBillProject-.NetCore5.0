using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.Entities.Domains;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BillServerServices
{
    public interface IBillServerService : IGenericService<BillServer>
    {
        public Task<IEnumerable<GetAllBillServerRequestDto>> GetAllActivatedAsync();

        public Task<IEnumerable<GetAllBillServerRequestDto>> GetAllUnActivatedAsync();

        public Task<IEnumerable<GetAllBillServerRequestDto>> GetAllAsync();

        public Task<CommandResponse> UpdateAsync(UpdateBillServerRequestDto item);

        public Task<CommandResponse> ActivateAsync(string Id);

        public Task<CommandResponse> UnActivateAsync(string Id);

        public Task<CommandResponse> CreateAsync(CreateBillServerRequestDto item);

        public Task<GetBillServerRequestDto> GetByIdAsync(string Id);

    }
}
