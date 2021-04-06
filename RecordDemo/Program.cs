using System;

namespace RecordDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Record1 r1a = new (FirstName: "Leandro", LastName: "Reis");
            Record1 r1b = new (FirstName: "Leandro", LastName: "Reis");
            Record1 r1c = new (FirstName: "Selin", LastName: "Civanbay");

            Class1 c1a = new (FirstName: "Ororo", LastName: "Munroe");
            Class1 c1b = new (FirstName: "Ororo", LastName: "Munroe");
            Class1 c1c = new (FirstName: "Susan", LastName: "Storm");

            Console.WriteLine("Record Type");
            Console.WriteLine($"To String: { r1a}");
            Console.WriteLine($"Are the two object equal: { Equals(r1a, r1b) }");
            Console.WriteLine($"Are the two object reference equal: { ReferenceEquals(r1a, r1b) }");
            Console.WriteLine($"Are the two object ==: { r1a == r1b }");
            Console.WriteLine($"Are the two object !=: { r1a != r1c }");
            Console.WriteLine($"Hash code of object A: { r1a.GetHashCode() }");
            Console.WriteLine($"Hash code of object B: { r1b.GetHashCode() }");
            Console.WriteLine($"Hash code of object C: { r1c.GetHashCode() }");


            Console.WriteLine();
            Console.WriteLine("************************************* ");
            Console.WriteLine("Class Type");
            Console.WriteLine($"To String: { c1a}");
            Console.WriteLine($"Are the two object equal: { Equals (c1a, c1b) }");
            Console.WriteLine($"Are the two object reference equal: { ReferenceEquals(c1a, c1b) }");
            Console.WriteLine($"Are the two object ==: { c1a == c1b }");
            Console.WriteLine($"Are the two object !=: { c1a != c1c }");
            Console.WriteLine($"Hash code of object A: { c1a.GetHashCode() }");
            Console.WriteLine($"Hash code of object B: { c1b.GetHashCode() }");
            Console.WriteLine($"Hash code of object C: { c1c.GetHashCode() }");
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
