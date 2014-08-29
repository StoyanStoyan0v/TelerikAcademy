namespace AddProducts
{
    using System;
    using System.Collections.Generic;
    using DatabaseHandlers;

    internal class ProductsInserter
    {
        private static void Main()
        {
            string dataBase = "Northwind";      
            DBHandler dbConnection = new SqlDBHandler(dataBase);

            string table = "Products";

            var records = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("ProductName","Coffe"),
                new KeyValuePair<string, object>("SupplierID",1),
                new KeyValuePair<string, object>("QuantityPerUnit","100kg"),
                new KeyValuePair<string, object>("UnitPrice",15.00m),
                new KeyValuePair<string, object>("Discontinued",false)
            };
            dbConnection.InsertIntoDatabase(records, table);
            Console.WriteLine("Product added into the table {0}!", table);

            records = new KeyValuePair<string, object>[]
            {
                new KeyValuePair<string, object>("ProductName","Pesho"),
                new KeyValuePair<string, object>("SupplierID",4),
                new KeyValuePair<string, object>("QuantityPerUnit","100kg"),
                new KeyValuePair<string, object>("UnitPrice",999999999.00m),
                new KeyValuePair<string, object>("Discontinued",false),
                new KeyValuePair<string, object>("CategoryID",5),
                new KeyValuePair<string, object>("UnitsInStock",50)
            };
            dbConnection.InsertIntoDatabase(records, table);
            Console.WriteLine("Product added into the table {0}!", table);
        }
    }
}