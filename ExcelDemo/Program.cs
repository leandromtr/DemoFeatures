using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ExcelDemo
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:\Demo\ExcelFile.xlsx");

            var people = GetSetupData();

            await SaveExcelFile(people, file);

        }

        private static async Task SaveExcelFile(List<PersonModel> people, FileInfo file)
        {
            DeleteIfExists(file);

            using var package = new ExcelPackage(file);
            var workSheet = package.Workbook.Worksheets.Add("MainReport");

            var range = workSheet.Cells["A1"].LoadFromCollection(people, true);
            range.AutoFitColumns();

            await package.SaveAsync();
        }

        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }

        private static List<PersonModel> GetSetupData()
        {
            List<PersonModel> output = new()
            {
                new() { Id = 1, FistName = "Leandro", LastName = "Reis" },
                new() { Id = 2, FistName = "Lucas", LastName = "Souza" },
                new() { Id = 3, FistName = "Teteus", LastName = "Silva" }
            };
            return output;
        }
    }
}
