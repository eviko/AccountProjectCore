using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AccountProjectCore.Models
{
    public class Account : EntityRoots
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }        
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }    
        public DateTime OpeningDatetime { get; set; }
        public DateTime ClosingDatetime { get; set; }
        public IList<AccountHolder> AccountAccountHolders { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public Account()
        {
            Transactions = new List<Transaction>();
            AccountAccountHolders = new List<AccountHolder>();
        }

    }


}
