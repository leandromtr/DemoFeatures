using System;
using System.Linq;

namespace YieldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the App");

            ListUsingDataAccess();
            ListUsingDataAccessYield();

            ListPrimeNumbers();
            ListPrimeNumbersSequence();

            Console.WriteLine("End of the App");
        }

        private static void ListPrimeNumbersSequence()
        {
            Console.WriteLine("-------- List Prime Numbers Sequence --------");

            var primeNumbers = Generators.GetPrimeNumber();

            var interator = primeNumbers.GetEnumerator();
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
        }

        private static void ListPrimeNumbers()
        {
            Console.WriteLine("--------  List Prime Numbers -------- ");

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
        }

        private static void ListUsingDataAccessYield()
        {
            Console.WriteLine("-------- List Using DataAccess Yield --------");
            var people = DataAccessYield.GetPeople();

            foreach (var p in people)
            {
                Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            }
        }

        private static void ListUsingDataAccess()
        {
            Console.WriteLine("-------- List Using DataAccess --------");

            var people = DataAccess.GetPeople();
            people = DataAccessYield.GetPeople();

            foreach (var p in people)
            {
                Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            }
            Console.WriteLine("");
        }
    }
}
