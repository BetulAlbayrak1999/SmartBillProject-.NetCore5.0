using MongoDB.Bson;
using System;

namespace SmartBill.Entities.Domains.MongoDB.DocumentBaseEntities
{
    public abstract class DocumentBaseEntity
    {
        public ObjectId Id { get; set; }
        public string ObjectId => Id.ToString();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
