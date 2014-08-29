namespace InsertIntoExcel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DatabaseHandlers;

    internal class ExcelInserter
    {
        private static void Main(string[] args)
        {
            var filePath = @"..\..\database.xlsx";
            DBHandler dbConnection = new OleDbHandler(filePath);

            var keys = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("FullName","Pesho Ivanov"),
                new KeyValuePair<string, object>("PersonalScore",15)
            };
            dbConnection.InsertIntoDatabase(keys, "Sheet1$");
            Console.WriteLine("Entry written into the excel file!");

            keys = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("FullName","Steve Wonder"),
                new KeyValuePair<string, object>("PersonalScore",50)
            };
            dbConnection.InsertIntoDatabase(keys, "Sheet1$");
            Console.WriteLine("Entry written into the excel file!");
        }
    }
}