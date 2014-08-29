namespace DAOAndTest
{
    using System;
    using System.Linq;

    public static class DAO
    {
        private static readonly NorthwindDBEntities context = new NorthwindDBEntities();

        public static void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public static void DeleteCustomer(string customerCompanyName)
        {
            var customer = context.Customers.First(c => c.CompanyName == customerCompanyName);
            
            ValidateCustomer(customer);

            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        public static void ModifyCustomer(string customerCompanyName, string newCompanyName, string newContanctName = null)
        {
            var customer = context.Customers.First(c => c.CompanyName == customerCompanyName);

            ValidateCustomer(customer);

            customer.CompanyName = newCompanyName;
            if (newContanctName != null)
            {
                customer.ContactName = newContanctName;
            }

            context.SaveChanges();
        }

        private static void ValidateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new NullReferenceException("There is not customer with this company name");
            }
        }
    }
}