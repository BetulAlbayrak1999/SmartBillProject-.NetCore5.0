using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.PaymentDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.ViewModels.PaymentVM;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.PaymentServices
{
    public interface IPaymentService : IGenericService<Payment> 
    {
        public Task<IEnumerable<GetAllPaymentRequestDto>> GetAllPaidAsync();

        public Task<IEnumerable<GetAllPaymentRequestDto>> GetAllUnPaidAsync();

        public Task<IEnumerable<GetAllPaymentRequestDto>> GetAllAsync();
        
        public Task<CommandResponse> CreateAsync(CreatePaymentRequestDto item);

        public Task<GetPaymentRequestDto> GetByIdAsync(string Id);

        /*public Task<IEnumerable<GetAllPaymentRequestDto>> GetAllPaymentByCustomerAsync(string Id);
        public Task<ListPaymentByCustomerVM> GetApplicationUserByEmailAsync(string email);*/

    }
}
