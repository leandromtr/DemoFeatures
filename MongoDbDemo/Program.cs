using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace MongoDbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AdressBook");

            db.InsertRecord("Users", new PersonModel { FirstName = "Leandro", LastName = "Reis" });

            PersonModel person = new PersonModel
            {
                FirstName = "Lucas Souza",
                LastName = "Reisddd",
                PrimaryAddress = new AddressModel
                {
                    StreetAddress = "123, Street",
                    City = "São Paulo",
                    State = "SP",
                    ZipCode = "188850",
                }
            };
            db.InsertRecord("Users", person);
            Console.ReadLine();
        }
    }

    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
    }

    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }




    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb+srv://dbUser:Mongodb123@clusterdemo.demwk.mongodb.net/");
            //var client = new MongoClient("mongodb+srv://dbUser:Mongodb123@clusterdemo.demwk.mongodb.net/AdressBook?retryWrites=true&w=majority");

            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    }
}
