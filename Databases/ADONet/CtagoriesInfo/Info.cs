namespace CtagoriesInfo
{
    using System;
    using DatabaseHandlers;

    internal class Info
    {
        private static void Main(string[] args)
        {
            string dataBase = "Northwind";      
            DBHandler dbConnection = new SqlDBHandler(dataBase);

            var result =
                dbConnection.SelectFromTable(new string[] { "CategoryName", "Description" }, "Categories");
            foreach (var pair in result)
            {
                Console.WriteLine("CategoryName: {0}", pair.Key);
                Console.WriteLine("Description: {0}", pair.Value);
                Console.WriteLine(new string('-',40));
            }
        }
    }
}