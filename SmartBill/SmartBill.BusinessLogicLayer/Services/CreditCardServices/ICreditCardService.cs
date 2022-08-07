using MongoDB.Bson;
using SmartBill.Entities.Domains.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CreditCardServices
{
    public interface ICreditCardService
    {
        void CreateCreditCard(CreditCard model);

        void UpdateCreditCard(CreditCard model);

        void ActivateCreditCard(ObjectId Id);

        void UnActivateCreditCard(ObjectId Id);

        CreditCard GetCreditCard(ObjectId Id);

        IEnumerable<CreditCard> GetAllCreditCard();
    }
}
