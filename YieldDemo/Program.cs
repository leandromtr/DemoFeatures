using System;
using System.Collections.Generic;

namespace YieldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the App");

            var people = DataAccess.GetPeople();
            people = DataAccessYield.GetPeople();

            foreach(var p in people)
            {
                Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            }
            Console.WriteLine("");

            people = DataAccessYield.GetPeople();

            foreach (var p in people)
            {
                Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            }

            Console.WriteLine("End of the App");
        }
    }

    public class DataAccessYield
    {
        public static IEnumerable<PersonModel> GetPeople()
        {
            yield return new PersonModel("Leandro", "Reis");
            yield return new PersonModel("Lucas", "Sousa");
            yield return new PersonModel("Teteus", "Reis");
        }
    }

    public class DataAccess
    {
        public static IEnumerable<PersonModel> GetPeople()
        {
            List<PersonModel> output = new();

            output.Add(new PersonModel("Leandro", "Reis"));
            output.Add(new PersonModel("Lucas", "Sousa"));
            output.Add(new PersonModel("Teteus", "Reis"));

            return output;
        }
    }

}
