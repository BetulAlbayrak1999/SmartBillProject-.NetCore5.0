using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.ViewModels.BankAccountVM;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BankAccountServices
{
    public interface IBankAccountService : IGenericService<BankAccount>
    {
        public Task<IEnumerable<GetAllBankAccountRequestDto>> GetAllActivatedAsync();

        public Task<IEnumerable<GetAllBankAccountRequestDto>> GetAllUnActivatedAsync();

        public Task<IEnumerable<GetAllBankAccountRequestDto>> GetAllAsync();

        public Task<CommandResponse> UpdateAsync(UpdateBankAccountRequestDto item);

        public Task<CommandResponse> ActivateAsync(string Id);

        public Task<CommandResponse> UnActivateAsync(string Id);

        public Task<CommandResponse> CreateAsync(CreateBankAccountRequestDto item);

        public Task<GetBankAccountRequestDto> GetByIdAsync(string Id);
        //public Task<IEnumerable<ApplicationUserDropDownListVM>> GetUsers();

    }
}
