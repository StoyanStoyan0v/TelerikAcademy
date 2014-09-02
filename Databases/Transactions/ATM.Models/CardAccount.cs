namespace ATM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class CardAccount
    {
        public CardAccount()
        {
            this.Transactions = new HashSet<TransactionHistory>();
        }

        public int Id { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public string CardNumber { get; set; }

        [MaxLength(4)]
        [MinLength(4)]
        public string CardPIN { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<TransactionHistory> Transactions { get; set; }
    }
}