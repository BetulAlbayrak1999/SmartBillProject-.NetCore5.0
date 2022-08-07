using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.DocumentRepositories
{
    public interface IDocumentRepository<T> where T : class
    {
        void Create(T document);

        void Update(T document);

         T Get(ObjectId id);

        T Get(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null);

    }
}
