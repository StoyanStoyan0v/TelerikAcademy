namespace BanAccounts
{
    using System;
    using System.Linq;

    public class Individual : Customer
    {
        //In bulgarian (ЕГН):
        private string pin;

        public Individual(string name, string pin) : base(name)
        {
            this.Pin = pin;
        }

        public string Pin
        {
            get
            {
                return this.pin;
            }
            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("The person's ID number must be exactly 9 numbers long!");
                }

                if (value.Any(x => !Char.IsDigit(x)))
                {
                    throw new ArgumentException("The person's ID number must contain only digits!");
                }

                this.pin = value;
            }
        }
    }
}
