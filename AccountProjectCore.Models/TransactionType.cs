using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Models
{
    public class TransactionType : EntityRoots
    {
        public string Name { get; set; } // withdraw,transfer,exchange,pay\        
        public ChargeType ChargeType { get; set; }
    }

    public enum ChargeType { Credit=1, Debit=2 };
}
