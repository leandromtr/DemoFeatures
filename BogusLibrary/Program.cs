using Bogus;
using BogusLibrary;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        var languageCode = GetLanguage();

        GenerateClient(languageCode);
        GenerateCompany(languageCode);
        GenerateVehicle(languageCode);
        GenerateFinance(languageCode);
        GenerateCommerce(languageCode);
        Console.ReadLine();
    }

    public static string GetLanguage()
    {
        Console.WriteLine("--------------------- FAKE DATA GENERATOR ---------------------");
        Console.WriteLine("1 - English                                   5 - Portuguese ");
        Console.WriteLine("2 - French                                    6 - Spanish");
        Console.WriteLine("3 - German                                    7 - Swedish");
        Console.WriteLine("4 - Italian                                   8 - Turkish");
        Console.WriteLine("");
        Console.WriteLine("Choose the Language:");
        var code = Console.ReadLine();

        var languageCode = string.Empty;
        if (code == "1") languageCode = "en_US";
        if (code == "2") languageCode = "fr";
        if (code == "3") languageCode = "de";
        if (code == "4") languageCode = "it";
        if (code == "5") languageCode = "pt_BR";
        if (code == "6") languageCode = "es";
        if (code == "7") languageCode = "sv";
        if (code == "8") languageCode = "tr";

        if (string.IsNullOrEmpty(languageCode))
            languageCode = "en_US";

        Console.Clear();

        return languageCode;
    }

    public static void GenerateCompany(string languageCode)
    {
        var companies = FakeData.ListCompaniesFake(languageCode);
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine("                                         Companies                                          ");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var company in companies)
        {
            Console.WriteLine(string.Format("Name: {0}  Catch Phrase: {1}", company.CompanyName.ToString().PadRight(34, ' '), company.CatchPhrase.ToString()));
            Console.WriteLine(string.Format("Suffix: {0}  Bs: {1}", company.CompanySuffix.ToString().PadRight(32, ' '), company.Bs.ToString()));
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    public static void GenerateVehicle(string languageCode)
    {
        var vehicles = FakeData.ListVehiclesFake(languageCode);
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine("                                         Vehicles                                           ");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(string.Format("Vin: {0}", vehicle.Vin.ToString()));
            Console.WriteLine(string.Format("Model: {0}", vehicle.Model.ToString()));
            Console.WriteLine(string.Format("Model: {0}", vehicle.Type.ToString()));
            Console.WriteLine(string.Format("Manufacturer: {0}", vehicle.Manufacturer.ToString()));
            Console.WriteLine(string.Format("Fuel: {0}", vehicle.Fuel.ToString()));
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    public static void GenerateClient(string languageCode)
    {
        var clientes = FakeData.ListClientsFake(languageCode);
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine("                                          Clients                                           ");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var client in clientes)
        {
            Console.WriteLine(string.Format("Id: {0}", client.Id.ToString()));
            Console.WriteLine(string.Format("Name: {0}  Address: {1}  Birthday: {2}", client.Name.ToString().PadRight(31, ' '), client.Address.ToString().PadRight(31, ' '), client.Birthday.ToString().Substring(1, 10).PadRight(17, ' ')));
            Console.WriteLine(string.Format("Email: {0}  City: {1}  Active: {2}", client.Email.ToString().PadRight(30, ' '), client.City.ToString().PadRight(34, ' '), client.Active.ToString().PadRight(5, ' ')));
            Console.WriteLine(string.Format("Father's Name: {0} ZipCode: {1}  Salary: {2}", client.FatherName.ToString().PadRight(23, ' '), client.ZipCode.ToString().PadRight(31, ' '), client.Salary.ToString().PadRight(20, ' ')));
            Console.WriteLine(string.Format("Mother's Name: {0}  Phone: {1}", client.MotherName.ToString().PadRight(22, ' '), client.Phone.ToString().PadRight(20, ' ')));
            //Console.WriteLine(cli.Gender);
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    public static void GenerateFinance(string languageCode)
    {
        var finances = FakeData.ListFinancesFake(languageCode);
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine("                                          Finances                                          ");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var finance in finances)
        {

            Console.WriteLine(string.Format("Account: {0}", finance.Account.ToString()));
            Console.WriteLine(string.Format("AccountName: {0}  TransactionType: {1}  Amount: {2}", finance.AccountName.ToString().PadRight(31, ' '), finance.TransactionType.ToString().PadRight(13, ' '), finance.Amount.ToString().PadRight(20, ' ')));
            Console.WriteLine(string.Format("CreditCardNumber: {0}  CreditCardCvv: {1}  Iban: {2}", finance.CreditCardNumber.ToString().PadRight(26, ' '), finance.CreditCardCvv.ToString().PadRight(15, ' '), finance.Iban.ToString().PadRight(23, ' ')));
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    public static void GenerateCommerce(string languageCode)
    {
        var commerces = FakeData.ListCommercesFake(languageCode);
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine("                                         Commerces                                          ");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        foreach (var commerce in commerces)
        {
            Console.WriteLine(string.Format("Product: {0}  ProductName: {1}", commerce.Product.ToString().PadRight(35, ' '), commerce.ProductName.ToString()));
            Console.WriteLine(string.Format("Department: {0}  Color: {1}  Price: {2}", commerce.Department.ToString().PadRight(32, ' '), commerce.Color.ToString().PadRight(35, ' '), commerce.Price.ToString().PadRight(10, ' ')));
            Console.WriteLine(string.Format("ProductAdjective: {0}  ProductMaterial: {1}", commerce.ProductAdjective.ToString().PadRight(26, ' '), commerce.ProductMaterial.ToString().PadRight(23, ' ')));
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }
}
