namespace SearchProducts
{
    using System;
    using DatabaseHandlers;

    internal class Searcher
    {
        private static void Main(string[] args)
        {
            string dataBase = "Northwind";
            DBHandler dbConnection = new SqlDBHandler(dataBase);

            string pattern = Console.ReadLine();
            var escapedPattern = pattern.Replace("\"", "\\\"")
                                        .Replace(@"\", @"\\")
                                        .Replace("_", "\\_")
                                        .Replace("%", @"\%")
                                        .Replace("'", "''");

            string table = "Products WHERE ProductName LIKE '%" + escapedPattern + "%' ESCAPE '\\'";

            var result =
                dbConnection.SelectFromTable(new string[] { "ProductName" }, table);
            Console.WriteLine("Products containing the pattern: {0}", pattern);
            Console.WriteLine(new string('-',30));
            foreach (var item in result)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}