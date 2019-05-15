using AccountProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Repository.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {        
        Account GetAccountWithHolders(int accountId);
        Account GetAccountWithTransactions(int accountId);
    }
}
