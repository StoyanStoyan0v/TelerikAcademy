using System;
using System.Linq;

namespace ObserverPattern
{
    public class Investor : IInvestor
    {
        private readonly string _name;

        // Constructor
        public Investor(string name)
        {
            this._name = name;
        }
 
        // Gets or sets the stock
        public Stock Stock { get; set; }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {{0}} of {{1}}'s change to {{2:C}}", this._name, stock.Symbol, stock.Price);
        }
    }
}