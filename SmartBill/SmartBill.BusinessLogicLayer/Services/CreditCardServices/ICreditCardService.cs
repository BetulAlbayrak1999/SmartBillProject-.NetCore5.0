using MongoDB.Bson;
using SmartBill.Entities.Domains.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CreditCardServices
{
    public interface ICreditCardService
    {
        void CreateCreditCard(CreditCardPayment model);

        void UpdateCreditCard(CreditCardPayment model);

        void ActivateCreditCard(ObjectId Id);

        void UnActivateCreditCard(ObjectId Id);

        CreditCardPayment GetCreditCard(ObjectId Id);

        IEnumerable<CreditCardPayment> GetAllCreditCard();
    }
}
