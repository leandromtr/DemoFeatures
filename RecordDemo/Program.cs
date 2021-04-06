using System;

namespace RecordDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Record1 r1a = new (FirstName: "Leandro", LastName: "Reis");
            Record1 r1b = new (FirstName: "Selin", LastName: "Civanbay");
            Record1 r1c = new (FirstName: "Lucas", LastName: "Souza");

            Class1 c1a = new (FirstName: "Ororo", LastName: "Munroe");
            Class1 c1b = new (FirstName: "Jean", LastName: "Grey");
            Class1 c1c = new (FirstName: "Susan", LastName: "Storm");

            Console.WriteLine("Record Type");
            Console.WriteLine($"To String: { r1a}");

            Console.WriteLine();
            Console.WriteLine("Record Type");
            Console.WriteLine("Record Type");
            Console.WriteLine("Class Type");
            Console.WriteLine($"To String: { c1a}");

        }

        // A record is just a fancy read-only class
        public record Record1(string FirstName, string LastName);

        public class Class1
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }

            public Class1(string FirstName, string LastName)
            {
                this.FirstName = FirstName;
                this.LastName = LastName;
            }
        }
    }
}
