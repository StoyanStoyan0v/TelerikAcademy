namespace BanAccounts
{
    using System;
    using System.Linq;

    public class Company : Customer
    {
        //Bulstat
        private string id;

        public Company(string name, string id) :base(name)
        {
            this.ID = id;
        }
        public string ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                if(value.Length!=9)
                {
                    throw new ArgumentException("The company's ID number must be exactly 9 numbers long!");
                }
                
                if(value.Any(x=>!Char.IsDigit(x)))
                {
                    throw new ArgumentException("The company's ID number must contain only digits!");
                }

                this.id = value;
            }
        }
    }
}
