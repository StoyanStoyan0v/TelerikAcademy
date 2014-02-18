using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanAccounts
{
    public class Bank
    {
        public Bank()
        {
            this.Accounts = new List<Account>();
        }

        public List<Account> Accounts { get; private set; }
    }
}