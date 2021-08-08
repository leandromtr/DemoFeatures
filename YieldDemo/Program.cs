using System;
using System.Collections.Generic;
using System.Linq;

namespace YieldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the App");

            var people = DataAccess.GetPeople();
            people = DataAccessYield.GetPeople();

            foreach (var p in people)
            {
                Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            }
            Console.WriteLine("");

            people = DataAccessYield.GetPeople();

            foreach (var p in people)
            {
                Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            }

            var primeNumbers = Generators.GetPrimeNumber().Take(10);

            foreach (var prime in primeNumbers)
            {
                Console.WriteLine(prime);
            }

            foreach (var prime in primeNumbers)
            {
                Console.WriteLine(prime);
            }

            Console.WriteLine("Waiting for user input");
            Console.ReadLine();

            primeNumbers = Generators.GetPrimeNumber().Take(15);
            foreach (var prime in primeNumbers)
            {
                Console.WriteLine(prime);
            }




            var primeNumbers2 = Generators.GetPrimeNumber();

            var interator = primeNumbers2.GetEnumerator();
            for (int i = 0; i < 10; i++)
            {
                if (interator.MoveNext())
                {
                    Console.WriteLine(interator.Current);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Waiting for user input");
            Console.ReadLine();

            for (int i = 0; i < 15; i++)
            {
                if (interator.MoveNext())
                {
                    Console.WriteLine(interator.Current);
                }
                else
                {
                    break;
                }
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


    public class Generators
    {
        public static IEnumerable<int> GetPrimeNumber()
        {
            int counter = 1;
            while (true)
            {
                if (IsPrimeNumber(counter))
                {
                    yield return counter;
                }
                counter++;
            }
        }

        private static bool IsPrimeNumber(int value)
        {
            bool output = true;
            for (int i = 2; i < value / 2; i++)
            {
                if (value % i == 0)
                {
                    output = false;
                    break;
                }
            }
            return output;
        }

    }

}
