using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AdressBook");

            //db.InsertRecord("Users", new PersonModel { FirstName = "Teteus", LastName = "Santos" });

            //PersonModel person = new PersonModel
            //{
            //    FirstName = "Lucas Souza",
            //    LastName = "Reisddd",
            //    PrimaryAddress = new AddressModel
            //    {
            //        StreetAddress = "123, Street",
            //        City = "São Paulo",
            //        State = "SP",
            //        ZipCode = "188850",
            //    }
            //};
            //db.InsertRecord("Users", person);



            // Return
            //var recs = db.LoadRecords<PersonModel>("Users");
            //foreach(var rec in recs)
            //{
            //    Console.WriteLine($"{ rec.Id}: { rec.FirstName} { rec.LastName}");

            //    if (rec.PrimaryAddress != null)
            //    {
            //        Console.WriteLine(rec.PrimaryAddress.City);
            //    }
            //    Console.WriteLine();
            //}


            var recs = db.LoadRecords<NameModel>("Users");
            foreach (var rec in recs)
            {
                Console.WriteLine($"{ rec.Id}:{ rec.FirstName} { rec.LastName}");
                Console.WriteLine();
            }


            //var oneRecord = db.LoadRecordById<PersonModel>("Users", new Guid("e90553db-1e84-46e8-b20e-03324b18bee9"));
            //Console.WriteLine($"{ oneRecord.Id}: { oneRecord.FirstName} { oneRecord.LastName}");
            //oneRecord.DateOfBirthday = new DateTime(1987, 03, 18, 0, 0, 0, DateTimeKind.Utc);
            //db.UpsertRecord("Users", oneRecord.Id, oneRecord);

            //db.DeleteRecord<PersonModel>("Users", oneRecord.Id);

            Console.ReadLine();
        }
    }

    public class NameModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class PersonModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel PrimaryAddress { get; set; }
        [BsonElement("dob")]
        public DateTime DateOfBirthday { get; set; }
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

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var results = collection.ReplaceOne(new BsonDocument("_id", id), record, new UpdateOptions { IsUpsert = true});
        }

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}
