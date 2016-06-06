using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    class Database
    {
        public MongoDB.Driver.IMongoDatabase database;
        private string databaseName = "majddb";
        public Database()
        {
            database = Connection.Instance.client.GetDatabase(databaseName);
        }
    }
}
