using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Connection
    {
        public MongoClient client;
        private Connection instance;
        public static Connection Instance { get { return Instance??new Connection(); } }
        private Connection(string dbuser="", string password="")
        {
            client = new MongoClient(string.Format("mongodb://{0}:{1}@ds036709.mlab.com:36709/majddb",dbuser,password));
        }
    }
}
