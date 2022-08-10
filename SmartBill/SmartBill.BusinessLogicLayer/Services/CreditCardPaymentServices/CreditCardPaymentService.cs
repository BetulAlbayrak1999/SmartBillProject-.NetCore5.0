using MongoDB.Bson;
using SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.CreditCardPaymentRepositories;
using SmartBill.Entities.Domains.MongoDB;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartBill.BusinessLogicLayer.Services.CreditCardServices
{
    public class CreditCardPaymentService : ICreditCardPaymentService
    {
        private readonly ICreditCardPaymentRepository _repository;

        public CreditCardPaymentService(ICreditCardPaymentRepository repository)
        {
            _repository = repository;
        }
        public void ActivateCreditCardPayment(ObjectId Id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateCreditCardPayment(CreditCardPayment model)
        {
            try
            {
                _repository.Create(model);
            }
            catch(Exception ex) { }
        }

        public IEnumerable<CreditCardPayment> GetAllCreditCardPayment()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex) { return null; }
        }

        public CreditCardPayment GetCreditCardPayment(ObjectId Id)
        {
            try
            {
                return _repository.Get(Id);
            }
            catch (Exception ex) { return null; }
        }

        public void UnActivateCreditCardPayment(ObjectId Id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCreditCardPayment(CreditCardPayment model)
        {
            try
            {
                _repository.Update(model);
            }
            catch (Exception ex) { }
        }
    }
}
