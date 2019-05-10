using AccountProjectCore.Models;
using AccountProjectCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountProjectCore.Repository
{
    public class HolderRepository : Repository<Holder>, IHolderRepository
    {
        public IEnumerable<AccountHolder> GetAccountsByAccountHolder(int holderId)
        {
            return _context.AccountHolders.Where(i => i.HolderId == holderId);
        }
    }
}
