using MongoDB.Bson;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.CreditCardPaymentDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CreditCardPaymentServices
{
    public interface ICreditCardPaymentService
    {
        public Task<CommandResponse> CreateCreditCardPayment(CreateCreditCardPaymentRequestDto model);

        public CommandResponse UpdateCreditCardPayment(UpdateCreditCardPaymentRequestDto model);


        public Task<GetCreditCardPaymentRequestDto> GetCreditCardPayment(ObjectId Id);

        public IEnumerable<GetAllCreditCardPaymentRequestDto>  GetAllCreditCardPayment();
    }
}
