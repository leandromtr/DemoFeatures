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
            WorkingWithArrays();
            PadAndTrim();
            SearchingString();
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

            results = lastName + ", my name is " + firstName + " " + lastName;
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

        private static void WorkingWithArrays()
        {
            int[] ages = new int[] { 6, 7, 8, 9, 10 };
            string results;

            results = String.Concat(ages);
            Console.WriteLine(results);

            results = String.Join(",", ages);
            Console.WriteLine(results);

            string testString = "Leo,Line,Le,Tetesus,Leka,";
            string[] resultArray = testString.Split(',');

            Array.ForEach(resultArray, x => Console.WriteLine(x));
        }

        private static void PadAndTrim()
        {
            string testString = "    Vai Corinthians!! ";
            string results;

            results = testString.TrimStart();
            Console.WriteLine($"'{results}'");

            results = testString.TrimEnd();
            Console.WriteLine($"'{results}'");

            results = testString.Trim();
            Console.WriteLine($"'{results}'");

            testString = "1.15";
            results = testString.PadLeft(10, '0');
            Console.WriteLine(results);

            results = testString.PadRight(10, '0');
            Console.WriteLine(results);
        }

        private static void SearchingString()
        {
            string testString = "This is a test of the search. Let's see how its testing works out.";
            bool resultsBoolean;
            int resultsInt;

            resultsBoolean = testString.StartsWith("This is ");
            Console.WriteLine($"Starts with \"This is\" : {resultsBoolean}");

            resultsBoolean = testString.StartsWith("Thhis is ");
            Console.WriteLine($"Starts with \"This is\" : {resultsBoolean}");

            resultsBoolean = testString.EndsWith("works out.");
            Console.WriteLine($"Ends with \"works out.\" : {resultsBoolean}");

            resultsBoolean = testString.EndsWith("workss out.");
            Console.WriteLine($"Ends with \"works out.\" : {resultsBoolean}");

            resultsBoolean = testString.Contains("search");
            Console.WriteLine($"Contains \"search\" : {resultsBoolean}");

            resultsBoolean = testString.Contains("searchh");
            Console.WriteLine($"Contains \"search\" : {resultsBoolean}");

            resultsInt = testString.IndexOf("test");
            Console.WriteLine($"Index of \"test\" : {resultsInt}");

            resultsInt = testString.IndexOf("test", 11);
            Console.WriteLine($"Index of \"test\" after character 11: {resultsInt}");

            resultsInt = testString.IndexOf("test", 49);
            Console.WriteLine($"Index of \"test\" after character 48: {resultsInt}");

            resultsInt = testString.LastIndexOf("test");
            Console.WriteLine($"Index of \"test\" : {resultsInt}");

            resultsInt = testString.LastIndexOf("test", 48);
            Console.WriteLine($"Index of \"test\" before character 48: {resultsInt}");

            resultsInt = testString.LastIndexOf("test", 10);
            Console.WriteLine($"Index of \"test\" before character 10: {resultsInt}");
        }
    }
}
