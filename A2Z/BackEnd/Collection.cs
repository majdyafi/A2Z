using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class Collection
    {
        public MongoDB.Driver.IMongoCollection<BsonDocument> collection;
        public long count { get { return collection.Count(new BsonDocument()); } }
        public string collectionName = "Dummy";
        public Collection(MongoDB.Driver.IMongoDatabase db)
        {
            collection = db.GetCollection<BsonDocument>(collectionName);
        }
    }
}
