using AccountProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Repository.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetTransactionsByTransactionDate(DateTime transactiondatetime);     
        IEnumerable<Transaction> GetTransactionsOfAccount(int accountId);
        IEnumerable<Transaction> GetTransactionsOfAccountForChargeType(int accountId, ChargeType chargeType);
    }
}
