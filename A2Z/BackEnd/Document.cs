using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackEnd
{
    class Document<T>
    {
        T ID;
        BsonDocument content;
        public enum TypeOfOperation {
            PUT,
            PATCH,
            GET,
            POST
        }
        Collection _collection;
        public Document(Collection collection)
        {
            this._collection = collection;
        }
        public bool action(Document<T> document, TypeOfOperation typeOfOperation)
        {
            bool result = true;
            switch(typeOfOperation)
            {
                case TypeOfOperation.GET:  getDocumentByKeyValue(document,"",""); break;
                case TypeOfOperation.POST: postDocument(document); break;
            }
            return result;
        }

        private async void postDocument(Document<T> document)
        {
            try
            {
                await _collection.collection.InsertOneAsync(document.content);
            }
            catch
	        {
                throw new Exception("Cannot create new document");
            }
        }

        private async void  getDocumentByKeyValue(Document<T> document,string key, string value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            var result = await _collection.collection.Find(filter).ToListAsync();
        }
    }
}
