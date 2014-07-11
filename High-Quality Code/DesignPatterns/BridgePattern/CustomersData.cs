using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgePattern
{
    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class CustomersData : DataObject
    {
        private readonly List<string> customers = new List<string>();
        private int current = 0;
 
        public CustomersData()
        {
            // Loaded from a database
            this.customers.Add("Jim Jones");
            this.customers.Add("Samual Jackson");
            this.customers.Add("Allen Good");
            this.customers.Add("Ann Stills");
            this.customers.Add("Lisa Giolani");
        }
 
        public override void NextRecord()
        {
            if (this.current <= this.customers.Count - 1)
            {
                this.current++;
            }
        }
 
        public override void PriorRecord()
        {
            if (this.current > 0)
            {
                this.current--;
            }
        }
 
        public override void AddRecord(string customer)
        {
            this.customers.Add(customer);
        }
 
        public override void DeleteRecord(string customer)
        {
            this.customers.Remove(customer);
        }
 
        public override void ShowRecord()
        {
            Console.WriteLine(this.customers[this.current]);
        }
 
        public override void ShowAllRecords()
        {
            foreach (string customer in this.customers)
            {
                Console.WriteLine(string.Format(" {0}", customer));
            }
        }
    }
}