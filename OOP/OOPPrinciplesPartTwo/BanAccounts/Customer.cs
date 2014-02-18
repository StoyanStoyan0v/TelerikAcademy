namespace BanAccounts
{
    using System;
    using System.Linq;

    public class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Customer name cannot be empty!");
                }
                this.name = value;
            }
        }
    }
}