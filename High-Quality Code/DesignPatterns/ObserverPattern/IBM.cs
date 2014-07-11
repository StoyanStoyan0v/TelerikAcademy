using System;
using System.Linq;

namespace ObserverPattern
{
    public class IBM : Stock
    {
        public IBM(string symbol, double price) : base(symbol, price)
        {
        }
    }
}