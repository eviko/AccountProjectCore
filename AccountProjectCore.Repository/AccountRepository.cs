using AccountProjectCore.Models;
using AccountProjectCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AccountProjectCore.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public Account GetAccountWithHolders(int accountId)
        {
            return _context.Accounts.Include(h => h.AccountAccountHolders).ThenInclude(h => h.Holder).Where(x => x.Id == accountId).FirstOrDefault();
        }     

        public Account GetAccountWithTransactions(int accountId)
        {
            return _context.Accounts.Include(h => h.Transactions).ThenInclude(x=>x.InTransactionType).Where(i => i.Id == accountId).FirstOrDefault();

        }
    }
}
