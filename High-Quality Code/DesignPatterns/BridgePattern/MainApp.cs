namespace BridgePattern
{
    using System;

    public static class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create RefinedAbstraction
            Customers customers = new Customers("Chicago");
 
            // Set ConcreteImplementor
            customers.Data = new CustomersData();
 
            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");
 
            customers.ShowAll();
 
            // Wait for user
            Console.ReadKey();
        }
    }
}