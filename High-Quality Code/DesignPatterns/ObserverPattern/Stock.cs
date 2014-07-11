using System;
using System.Collections.Generic;
using System.Linq;

namespace ObserverPattern
{
    public abstract class Stock
    {
        private readonly List<IInvestor> _investors = new List<IInvestor>();
 
        private double price;

        // Constructor
        public Stock(string symbol, double price)
        {
            this.Symbol = symbol;
            this.price = price;
        }
 
        // Gets or sets the price
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price != value)
                {
                    this.price = value;
                    this.Notify();
                }
            }
        }
 
        // Gets the symbol
        public string Symbol { get; private set; }

        public void Attach(IInvestor investor)
        {
            this._investors.Add(investor);
        }
 
        public void Detach(IInvestor investor)
        {
            this._investors.Remove(investor);
        }
 
        public void Notify()
        {
            foreach (IInvestor investor in this._investors)
            {
                investor.Update(this);
            }
 
            Console.WriteLine("");
        }
    }
}