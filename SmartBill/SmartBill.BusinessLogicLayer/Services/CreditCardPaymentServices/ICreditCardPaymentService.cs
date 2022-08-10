using MongoDB.Bson;
using SmartBill.Entities.Domains.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CreditCardServices
{
    public interface ICreditCardPaymentService
    {
        void CreateCreditCardPayment(CreditCardPayment model);

        void UpdateCreditCardPayment(CreditCardPayment model);

        void ActivateCreditCardPayment(ObjectId Id);

        void UnActivateCreditCardPayment(ObjectId Id);

        CreditCardPayment GetCreditCardPayment(ObjectId Id);

        IEnumerable<CreditCardPayment> GetAllCreditCardPayment();
    }
}
