using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace StringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StringConversion();
            StringAsArray();
            EscapeString();
            AppendingStrings();
            InterpolationAndLiteral();
            StringBuilderDemo();
        }

        private static void StringConversion()
        {
            string testString = "This is the FBI calling!";
            TextInfo currentTextInfo = CultureInfo.CurrentCulture.TextInfo;
            TextInfo englishTextInfo = new CultureInfo("en-US", false).TextInfo;
            string result;

            result = testString.ToLower();
            Console.WriteLine(result);

            result = testString.ToUpper();
            Console.WriteLine(result);

            result = currentTextInfo.ToTitleCase(testString);
            Console.WriteLine(result);

            result = englishTextInfo.ToTitleCase(testString);
            Console.WriteLine(result);
        }

        private static void StringAsArray()
        {
            string testString = "LeandroReis";

            for (int i = 0; i < testString.Length; i++)
            {
                Console.WriteLine(testString[i]);
            }
        }

        private static void EscapeString()
        {
            string results;
            results = "This is my \"test\" solution.";
            Console.WriteLine(results);

            results = "C:\\Demo\\Test.txt";
            Console.WriteLine(results);

            results = @"C:\Demo\Test.txt";
            Console.WriteLine(results);
        }

        private static void AppendingStrings()
        {
            string firstName = "Leandro";
            string lastName = "Reis";
            string results;

            results = lastName + ", my name is " + firstName  + " " + lastName;
            Console.WriteLine(results);

            results = string.Format("{1}, my name is {0} {1}", firstName, lastName);
            Console.WriteLine(results);

            results = $"{lastName}, my name is {firstName}  {lastName}";
            Console.WriteLine(results);
        }

        private static void InterpolationAndLiteral()
        {
            string testString = "Leandro Reis";
            string results = $@"C:\Demo\{testString}\{"\""}Test{"\""}.txt";
        }

        private static void StringBuilderDemo()
        {
            Stopwatch regularStopwatch = new Stopwatch();
            regularStopwatch.Start();

            string test = "";
            for (int i = 0; i < 10000; i++)
            {
                test += i;
            }
            regularStopwatch.Stop();
            Console.WriteLine($"Regular Stopwatch: {regularStopwatch.ElapsedMilliseconds} ms");


            Stopwatch builderStopwatch = new Stopwatch();
            builderStopwatch.Start();

            StringBuilder sb = new();

            for (int i = 0; i < 10000; i++)
            {
                sb.Append(i);
            }
            builderStopwatch.Stop();
            Console.WriteLine($"StringBuilder Stopwatch: {builderStopwatch.ElapsedMilliseconds} ms");
        }
    }
}
