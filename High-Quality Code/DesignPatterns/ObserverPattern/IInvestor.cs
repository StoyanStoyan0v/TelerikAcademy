using System;
using System.Linq;

namespace ObserverPattern
{
    public interface IInvestor
    {
        void Update(Stock stock);
    }
}