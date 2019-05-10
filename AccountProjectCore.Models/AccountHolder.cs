using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Models
{
    public class AccountHolder
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int HolderId { get; set; }
        public Holder Holder { get; set; }
    }
}
