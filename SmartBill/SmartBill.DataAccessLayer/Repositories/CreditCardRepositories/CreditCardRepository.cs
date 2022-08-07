using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SmartBill.DataAccessLayer.Repositories.DocumentRepositories;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.DataAccessLayer.Repositories.CreditCardRepositories
{
    public class CreditCardRepository : DocumentRepository<CreditCard>, ICrediCardRepository
    {
        private const string CollectionName = "CreditCard";

        public CreditCardRepository(MongoClient client, IConfiguration configuration) : base(client, configuration, CollectionName)
        {
        }
    }
}
