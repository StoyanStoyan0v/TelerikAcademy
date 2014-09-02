namespace ATM.ConsoleClient
{
    public class ATMConsoleClient
    {
        private static void Main()
        {
            var atm = new ATMController();
            atm.TransactMoney("AAA1234BBB", "1348", "412FF381BC", 200);
        }
    }
}