namespace BanAccounts
{
    using System;
    using System.Linq;

    public interface IWithdrawable
    {
        void Withdraw(decimal amount);
    }
}
