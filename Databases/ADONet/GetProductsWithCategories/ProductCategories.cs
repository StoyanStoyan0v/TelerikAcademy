namespace GetProductsWithCategories
{
    using System;
    using System.Linq;
    using DatabaseHandlers;

    internal class ProductCategories
    {
        private static void Main(string[] args)
        {
            string dataBase = "Northwind";      
            DBHandler dbConnection = new SqlDBHandler(dataBase);

            string joinedTables = "Categories c INNER JOIN Products p ON c.CategoryID = p.CategoryID GROUP BY  CategoryName, ProductName";

            var result =
                dbConnection.SelectFromTable(new string[] { "CategoryName", "ProductName" }, joinedTables);

            foreach (var pair in result)
            {
                Console.WriteLine("Category: {0}", pair.Key);
                Console.WriteLine("Products: {0}", pair.Value);
                Console.WriteLine(new string('-',40));
            }
        }
    }
}