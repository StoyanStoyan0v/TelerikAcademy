namespace DAOAndTest
{
    using System;

    public static class DAOTests
    {
        public static void ExecuteAllTests()
        {
            TestInsertion();
            TestDeletion();
            TestModification();
        }

        private static void TestInsertion()
        {
            Customer customer = new Customer()
            {
                CustomerID = "AAA",
                CompanyName = "Zagorka",
                ContactName = "Kebapcho Nadenichkove",
                City = "Stara Zagora",
                Country = "Bulgaria"
            };
            DAO.InsertCustomer(customer);
            Console.WriteLine("Customer inserted!");
        }

        private static void TestDeletion()
        {
            //The other customemrs have relations to two tables... I decided not to delete them.
            DAO.DeleteCustomer("Zagorka");
            Console.WriteLine("Customer deleted!");
        }

        private static void TestModification()
        {
            DAO.ModifyCustomer("Berglunds snabbköp", "Snab");
            Console.WriteLine("Customer modified!");

            DAO.ModifyCustomer("Ana Trujillo Emparedados y helados", "Ana", "Her mother");
            Console.WriteLine("Customer modified!");

        }
    }
}