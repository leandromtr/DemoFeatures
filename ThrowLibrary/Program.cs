using HelperLibrary;
using System.Text.RegularExpressions;
using Throw;


List<DateTime> dateList = new List<DateTime>()
{
    DateTime.Now,
    DateTime.Now.AddDays(-984),
    DateTime.Now.AddDays(34234),
};


List<int> ageList = new List<int>()
{
    34,
    11,
    143,
    76,
    18,
    -2
};

List<string> nameList = new List<string>()
{
    "Leandro Reis",
    "Lucas Silva",
    "Lessa de Oliveira",
    "Ana Sa",
    "Mateus Reis",
    "Raxptos Xavier",
    "Ana Sa",
    ""
};

ThrowMethods helpers = new();

//Name Validation
Console.WriteLine("");
Console.WriteLine("Example Name Validations");
Console.WriteLine("--------------------------------------------------------------------------------------------");
Console.WriteLine("Name                 - Error");
Console.WriteLine("--------------------------------------------------------------------------------------------");
foreach (var item in nameList)
{
    Console.WriteLine(string.Format("{0} - {1}", item.PadRight(20, ' '), helpers.NameValidation(item)));
}


//Numbers Validation
Console.WriteLine("");
Console.WriteLine("Example Numbers Validations");
Console.WriteLine("--------------------------------------------------------------------------------------------");
Console.WriteLine("Number               - Error");
Console.WriteLine("--------------------------------------------------------------------------------------------");
foreach (var item in ageList)
{
    Console.WriteLine(string.Format("{0} - {1}", item.ToString().PadRight(20, ' '), helpers.AdultAgeValidation(item)));
}


//DateTime Validation
Console.WriteLine("");
Console.WriteLine("Example DateTime Validations");
Console.WriteLine("--------------------------------------------------------------------------------------------");
Console.WriteLine("Date                 - Error");
Console.WriteLine("--------------------------------------------------------------------------------------------");
foreach (var item in dateList)
{
    Console.WriteLine(string.Format("{0} - {1}", item.ToString().PadRight(20, ' '), helpers.DateValidation(item)));
}
Console.ReadLine();

