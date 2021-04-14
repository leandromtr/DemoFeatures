using System;

namespace MongoDbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AdressBook");


            //Create Record PersonModel class
            //db.InsertRecord("Users", new PersonModel { FirstName = "Teteus", LastName = "Santos" });

            //Create Record using the PersonModel / AdressModel class
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


            // Return All Users and display
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

            // Return User by Id and display
            //var oneRecord = db.LoadRecordById<PersonModel>("Users", new Guid("e90553db-1e84-46e8-b20e-03324b18bee9"));
            //Console.WriteLine($"{ oneRecord.Id}: { oneRecord.FirstName} { oneRecord.LastName}");

            // Insert with doesn't exist or update if exist record
            //oneRecord.DateOfBirthday = new DateTime(1987, 03, 18, 0, 0, 0, DateTimeKind.Utc);
            //db.UpsertRecord("Users", oneRecord.Id, oneRecord);

            // Delete record by Id
            //db.DeleteRecord<PersonModel>("Users", oneRecord.Id);


            var recs = db.LoadRecords<NameModel>("Users");
            foreach (var rec in recs)
            {
                Console.WriteLine($"{ rec.Id}:{ rec.FirstName} { rec.LastName}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
