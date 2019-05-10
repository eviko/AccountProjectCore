using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Models
{
    public class Transaction : EntityRoots
    {
        public int InTransactionTypeId { get; set; }
        public TransactionType InTransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDatetime { get; set; }
        public int ForAccountId { get; set; }
        public Account ForAccount { get; set; }
    }
}
