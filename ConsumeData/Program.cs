using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeData
{
    class Program
    {
        static void Main(string[] args)
        {

            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("twitter");
            var collection = db.GetCollection<BsonDocument>("tweet");

            var filter = Builders<BsonDocument>.Filter.Eq("user", "Karoli");
            var result = collection.Find(filter).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);

            }
            Console.ReadLine();
        }
    }
}
