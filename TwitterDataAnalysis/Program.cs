using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace TwitterDataAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("Twitter");
             var collection = db.GetCollection<BsonDocument>("tweet");
            //List<String> counter = new List<string>();

            // Count  /1

           var result = collection.Find(FilterDefinition<BsonDocument>.Empty)
         .Project(Builders<BsonDocument>.Projection.Include("user").Exclude("_id")).ToList();
              BsonDocument[] dis = result.Distinct().ToArray();
              Console.WriteLine(dis.Count());

            // Mentioned  /2

            /*
             * db.collection.aggregate(
            {"$group" : { "_id": "$name", "count": { "$sum": 1 } } },
            {"$match": {"_id" :{ "$ne" : null } , "count" : {"$gt": 1} } }, 
            {"$sort": {"count" : -1} },
            {"$project": {"name" : "$_id", "_id" : 0} }     
            )*/
            var group = new BsonDocument
                {{ "$group", new BsonDocument
                   { { "_id", new BsonDocument{{
                                                     "user","$user"
                                                 }
                                             }
                                },
                                {
                                    "Count", new BsonDocument
                                                 {
                                                     {
                                                         "$sum", 1
                                                     }
                                                 }
                                }
                            }
                  }
                };
            var match = new BsonDocument
                {
                    {
                        "$match",
                        new BsonDocument
                            {

                                {"Count", new BsonDocument
                                                   {
                                                       {
                                                           "$gte", 2
                                                       }
                                                   }},


                                {"_id", new BsonDocument
                                                   {
                                                       {
                                                           "$ne", 0
                                                       }
                                                   }}
                            }
                    }
                };
            var sort = new BsonDocument
            {
                { "$sort", new BsonDocument{{"count", -1}} }
            };
            var project = new BsonDocument
                {
                    {
                        "$project",
                        new BsonDocument
                            {
                                {"name", "$_id"},
                                {"_id", 0},
                              
                            }
                    }
                };

            var pipeline = new[] { match, group, sort, project };

            foreach (var item in pipeline)
            {
                Console.WriteLine(item.ToString());
            }


            Console.ReadLine();
}

}
}




