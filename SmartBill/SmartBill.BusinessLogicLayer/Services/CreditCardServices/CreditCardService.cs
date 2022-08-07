using MongoDB.Bson;
using SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.CreditCardRepositories;
using SmartBill.Entities.Domains.MongoDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartBill.BusinessLogicLayer.Services.CreditCardServices
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICrediCardRepository _repository;

        public CreditCardService(ICrediCardRepository repository)
        {
            _repository = repository;
        }
        public void ActivateCreditCard(ObjectId Id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateCreditCard(CreditCard model)
        {
            try
            {
                _repository.Create(model);
            }
            catch(Exception ex) { }
        }

        public IEnumerable<CreditCard> GetAllCreditCard()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex) { return null; }
        }

        public CreditCard GetCreditCard(ObjectId Id)
        {
            try
            {
                return _repository.Get(Id);
            }
            catch (Exception ex) { return null; }
        }

        public void UnActivateCreditCard(ObjectId Id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCreditCard(CreditCard model)
        {
            try
            {
                _repository.Update(model);
            }
            catch (Exception ex) { }
        }
    }
}
