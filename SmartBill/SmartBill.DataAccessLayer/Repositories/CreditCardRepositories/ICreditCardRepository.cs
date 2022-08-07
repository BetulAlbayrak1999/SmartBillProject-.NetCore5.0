
using SmartBill.DataAccessLayer.Repositories.DocumentRepositories;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.DataAccessLayer.Repositories.CreditCardRepositories
{
    public interface ICrediCardRepository : IDocumentRepository<CreditCard>
    {
    }
}
