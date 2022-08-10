using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.DocumentRepositories;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.CreditCardPaymentRepositories
{
    public class CreditCardPaymentRepository : DocumentRepository<CreditCardPayment>, ICreditCardPaymentRepository
    {
        private const string CollectionName = "CreditCardPayment";

        public CreditCardPaymentRepository(MongoClient client, IConfiguration configuration) : base(client, configuration, CollectionName)
        {
        }
    }
}
