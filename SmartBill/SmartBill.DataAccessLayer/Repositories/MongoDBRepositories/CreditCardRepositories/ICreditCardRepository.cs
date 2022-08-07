using SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.DocumentRepositories;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.CreditCardRepositories
{
    public interface ICrediCardRepository : IDocumentRepository<CreditCard>
    {
    }
}
