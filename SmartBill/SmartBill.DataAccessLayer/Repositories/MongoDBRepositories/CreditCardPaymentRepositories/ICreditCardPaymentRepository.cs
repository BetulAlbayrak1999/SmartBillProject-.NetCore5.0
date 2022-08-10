using SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.DocumentRepositories;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.CreditCardPaymentRepositories
{
    public interface ICreditCardPaymentRepository : IDocumentRepository<CreditCardPayment>
    {
    }
}
