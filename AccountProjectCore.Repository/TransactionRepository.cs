using AccountProjectCore.Models;
using AccountProjectCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AccountProjectCore.Repository
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public IEnumerable<TransactionType> GetTransactionsByChargeType(ChargeType chargeType)
        {
            return _context.TransactionTypes.Where(t => t.ChargeType == chargeType);
        }

        public IEnumerable<Transaction> GetTransactionsByTransactionDate(DateTime transactiondatetime)
        {
            return _context.Transactions.Where(dt => dt.TransactionDatetime == transactiondatetime);
        }

        public IEnumerable<Transaction> GetTransactionsByType(int transactionTypeId)
        {
            return _context.Transactions.Where(tt => tt.InTransactionTypeId == transactionTypeId);
        }

        public IEnumerable<Transaction> GetTransactionsOfAccount(int accountId)
        {
            return _context.Transactions.Include(x => x.InTransactionType).Where(x => x.ForAccountId == accountId);
        }

        public IEnumerable<Transaction> GetTransactionsOfAccountForChargeType(int accountId, ChargeType chargeType)
        {
            var trnTypes = _context.TransactionTypes.Where(x => x.ChargeType == chargeType);

            return _context.Transactions.Include(x => x.InTransactionType).Where(x => x.ForAccountId == accountId && trnTypes.Contains(x.InTransactionType));
        }
    }
}
