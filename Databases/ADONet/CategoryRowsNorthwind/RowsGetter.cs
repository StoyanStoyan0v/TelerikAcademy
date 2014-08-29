namespace CategoryRowsNorthwind
{
    using System;
    using DatabaseHandlers;
    
    internal class RowsGetter
    {
        private static void Main()
        {
            string dataBase = "Northwind";      
            DBHandler dbConnection = new SqlDBHandler(dataBase);
            int categoriesCount = (int)dbConnection.AggregateTable("SELECT COUNT(*) FROM Categories");
            Console.WriteLine("Categories count: {0}", categoriesCount);
        }
    }
}