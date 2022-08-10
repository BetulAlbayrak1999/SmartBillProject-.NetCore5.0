using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.ViewModels.ApartmentVM;
using SmartBill.BusinessLogicLayer.ViewModels.BillVM;
using SmartBill.Entities.Domains;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BillServices
{
    public interface IBillService : IGenericService<Bill>
    {
        public Task<IEnumerable<GetAllBillRequestDto>> GetAllActivatedAsync();

        public Task<IEnumerable<GetAllBillRequestDto>> GetAllUnActivatedAsync();

        public Task<IEnumerable<GetAllBillRequestDto>> GetAllAsync();

        public Task<CommandResponse> UpdateAsync(UpdateBillRequestDto item);

        public Task<CommandResponse> ActivateAsync(string Id);

        public Task<CommandResponse> UnActivateAsync(string Id);

        public Task<CommandResponse> CreateAsync(CreateBillRequestDto item);

        public Task<GetBillRequestDto> GetByIdAsync(string Id);

        public Task<IEnumerable<ApartmentBillListVM>> GetActivatedApartments();
        public Task<IEnumerable<BillServerBillListVM>> GetActivatedBillServers();
    }
}
