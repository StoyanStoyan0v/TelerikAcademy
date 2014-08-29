namespace DAOAndTest
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Data.Entity.Infrastructure;

    internal class Excersizes
    {
        // IGNORE THE STUPID RED UNDERLINES IF SHOWS ANY..THE PROGRAM IS WORKING JUST FINE..
        private static void Main(string[] args)
        {
            //May throw exceptions if executed more than once (duplicate records insertion or requesting 
            //wrong data  if previously changed with update). Try changing the testing data...
            //DAOTests.ExecuteAllTests();

            GetOrders("Canada", 1997);
            Console.WriteLine();

            GetOrdersSQL("Canada", 1997);
            Console.WriteLine();

            GetSalseByPeriodAndRegion("SP", new DateTime(1998, 01, 01), new DateTime(1998, 12, 01));
            Console.WriteLine();

            try
            {
                CloneNorthwind("D:\\NorthWindTwin");
                Console.WriteLine("Database NorthwinTwin created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            PerformConcurentChanges();
            Console.WriteLine();

            GetEmployeeTeritories();
            Console.WriteLine();

            TransactionalInsert();
            Console.WriteLine();

            Console.WriteLine(GetTotalIncome("Exotic Liquids", new DateTime(1980, 01, 21), new DateTime(1999, 01, 22)));
        }

        //Task 3
        private static void GetOrders(string shipCountry, int year)
        {
            var context = new NorthwindDBEntities();
            var orders = context.Orders.Where(o => o.ShipCountry == shipCountry && o.OrderDate.Value.Year == year);

            Console.WriteLine("With entity query: ");
            foreach (var order in orders)
            {
                Console.WriteLine("Country: {0} | City: {1,-10} | Shipped: {2,-22} | Ship Name: {3}",
                    order.ShipCountry, order.ShipCity, order.ShippedDate.Value, order.ShipName);
            }
        }

        //Task 4
        private static void GetOrdersSQL(string shipCountry, int year)
        {
            Console.WriteLine("With SQL query:");
            var context = new NorthwindDBEntities();
            var orders = context.Database.SqlQuery<Order>("SELECT * FROM Orders WHERE ShipCountry = {0} AND YEAR(OrderDate) = {1}", shipCountry, year).ToList();
            foreach (var order in orders)
            {
                Console.WriteLine("Country: {0} | City: {1,-10} | Shipped: {2,-22} | Ship Name: {3}",
                    order.ShipCountry, order.ShipCity, order.ShippedDate.Value, order.ShipName);
            }
        }

        //Task 5
        private static void GetSalseByPeriodAndRegion(string region, DateTime startDate, DateTime endDate)
        {
            var context = new NorthwindDBEntities();
            var orders = context.Orders
                                .Where(o => o.ShipRegion == region &&
                                            (o.OrderDate > startDate && o.RequiredDate < endDate))
                                .Select(resultOrder => new
                                {
                                    ShipName = resultOrder.ShipName,
                                    OrderDate = resultOrder.OrderDate,
                                    RequireDate = resultOrder.RequiredDate,
                                    Region = resultOrder.ShipRegion
                                });

            Console.WriteLine("Orders in {0} region - from {1} to {2}: ", region, startDate.ToString(), endDate.ToString());
            foreach (var order in orders)
            {
                Console.WriteLine(string.Format("Ship Name: {0}", order.ShipName));
                Console.WriteLine(string.Format("Order Date: {0}", order.OrderDate));
                Console.WriteLine(string.Format("Require Date:{0}", order.RequireDate));
                Console.WriteLine(string.Format("Region: {0}", order.Region));
                Console.WriteLine(new string('-',10));
            }
        }

        //Task 6
        private static void CloneNorthwind(string clonedDataBaseFilePath)
        {
            //Create Database
            string createNorthwindCloneDB = string.Format("CREATE DATABASE NorthwindTwin ON PRIMARY (NAME = NorthwindTwin, FILENAME = '{0}.mdf', SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) LOG ON (NAME = NorthwindTwinLog, FILENAME = '{1}.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)", clonedDataBaseFilePath, clonedDataBaseFilePath);
            SqlConnection dbConForCreatingDB = new SqlConnection(
                "Server=LOCALHOST; Database=master; Integrated Security=true");
            dbConForCreatingDB.Open();            
            SqlCommand createDB = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
            createDB.ExecuteNonQuery();
            dbConForCreatingDB.Close();            
            //Clone Northwind database in the created above
            IObjectContextAdapter context = new NorthwindDBEntities();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();
            SqlConnection dbConForCloning = new SqlConnection(
                "Server=LOCALHOST; Database=NorthwindTwin; Integrated Security=true");
            dbConForCloning.Open();            
            SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCloning);
            cloneDB.ExecuteNonQuery();
            dbConForCloning.Close();
        }

        //Task 7
        private static void PerformConcurentChanges()
        {
            var firstContext = new NorthwindDBEntities();
            var secondContext = new NorthwindDBEntities();
            var firstCtxEmp = firstContext.Employees.Find(1);
            var secontCtxEmp = secondContext.Employees.Find(1);
            
            firstCtxEmp.FirstName = "Stamat";
            firstCtxEmp.LastName = "Ivanov";  
            firstContext.SaveChanges();
            firstContext.Dispose();

            secontCtxEmp.FirstName = "Ivan";
            secontCtxEmp.LastName = "Georgiev";          
            secondContext.SaveChanges();
            secondContext.Dispose();
            Console.WriteLine("Changes successfully applied!");
        }

        //Task 8
        private static void GetEmployeeTeritories()
        {
            var context = new NorthwindDBEntities();
            var employee = context.Employees.Find(1);
            foreach (var item in employee.TeritoryEntries)
            {
                Console.WriteLine("Territory id: {0}", item.TerritoryID);
                Console.WriteLine("Territory description: {0}", item.TerritoryDescription);
            }
        }

        //Task 9
        private static void TransactionalInsert()
        {
            using (var context = new NorthwindDBEntities())
            {
                using (var contextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var order = new Order()
                        {
                            OrderDate = DateTime.Now,
                            RequiredDate = new DateTime(2016, 12, 2),
                            ShipCountry = "Netherlands",
                            ShipCity = "Rotterdam",
                            ShipName = "Pesho"
                        };
                        context.Orders.Add(order);
                        context.SaveChanges();
                        contextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        contextTransaction.Commit();
                    }
                }
            }
        }

        //Task 10
        private static decimal? GetTotalIncome(string supplierName, DateTime startDate, DateTime endDate)
        {
            var context = new NorthwindDBEntities();

            var totalIncome = context.usp_GetTotalIncome(supplierName, startDate, endDate).First();
            //I've tried 10000 ways... always return null value ????
            return totalIncome;
        }
    }
}