using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartBill.Entities.Domains.MongoDB.DocumentBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.DocumentRepositories
{
    public abstract class DocumentRepository<T> : IDocumentRepository<T> where T : DocumentBaseEntity

    {
        private readonly IMongoCollection<T> _collection;
        protected DocumentRepository(MongoClient client, IConfiguration configuration, string collectionName)
        {
            var database = client.GetDatabase(configuration.GetSection("MongoDatabase").Value);
            _collection = database.GetCollection<T>(collectionName);
        }
        public void Create(T document)
        {
            _collection.InsertOne(document);
        }

        public T Get(ObjectId id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _collection.Find(expression).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(expression);
        }

      
        public void Update(T document)
        {
            _collection.FindOneAndReplace(x => x.Id == document.Id, document);
        }
    }
}
