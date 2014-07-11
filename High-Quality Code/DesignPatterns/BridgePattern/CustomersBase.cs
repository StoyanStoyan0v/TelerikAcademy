using System;
using System.Linq;

namespace BridgePattern
{
    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class CustomersBase
    {
        protected string group;
 
        public CustomersBase(string group)
        {
            this.group = group;
        }
 
        // Property
        public DataObject Data { get; set; }
 
        public virtual void Next()
        {
            this.Data.NextRecord();
        }
 
        public virtual void Prior()
        {
            this.Data.PriorRecord();
        }
 
        public virtual void Add(string customer)
        {
            this.Data.AddRecord(customer);
        }
 
        public virtual void Delete(string customer)
        {
            this.Data.DeleteRecord(customer);
        }
 
        public virtual void Show()
        {
            this.Data.ShowRecord();
        }
 
        public virtual void ShowAll()
        {
            Console.WriteLine(string.Format("Customer Group: {0}", this.group));
            this.Data.ShowAllRecords();
        }
    }
}