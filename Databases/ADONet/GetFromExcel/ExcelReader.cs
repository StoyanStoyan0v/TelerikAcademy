namespace GetFromExcel
{
    using System;
    using DatabaseHandlers;

    internal class ExcelReader
    {
        private static void Main(string[] args)
        {
            var filePath = @"..\..\database.xlsx";            
            DBHandler dbConnection = new OleDbHandler(filePath);

            var excelTable = dbConnection.SelectFromTable(new string[] { "FirstName", "PersonalScore" }, "Sheet1$");

            Console.WriteLine("FirstName:      | PersonalScore: |");
            Console.WriteLine(new string('-',34));
            foreach (var pair in excelTable)
            {
                Console.WriteLine("{0,-15} |{1,8}        |", pair.Key, pair.Value);
            }
            Console.WriteLine(new string('-',34));
        }
    }
}