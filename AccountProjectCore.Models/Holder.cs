using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Models
{
    public class Holder : EntityRoots
    {
        public string Name { get; set; }
        public string Adreess { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Passport { get; set; }
        public string VatNumber { get; set; }
        public IList<AccountHolder> AccountHolders { get; set; }
        public Holder()
        {
            AccountHolders = new List<AccountHolder>();
        }
    }
}
