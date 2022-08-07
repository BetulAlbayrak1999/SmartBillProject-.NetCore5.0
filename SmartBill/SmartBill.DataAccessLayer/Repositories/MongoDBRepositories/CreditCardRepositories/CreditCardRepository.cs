using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.DocumentRepositories;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.CreditCardRepositories
{
    public class CreditCardRepository : DocumentRepository<CreditCardPayment>, ICrediCardRepository
    {
        private const string CollectionName = "CreditCard";

        public CreditCardRepository(MongoClient client, IConfiguration configuration) : base(client, configuration, CollectionName)
        {
        }
    }
}
