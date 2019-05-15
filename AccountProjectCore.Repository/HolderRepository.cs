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
    public class HolderRepository : Repository<Holder>, IHolderRepository
    {
        public IEnumerable<AccountHolder> GetAccountsByAccountHolder(int holderId)
        {
            return _context.AccountHolders.Where(i => i.HolderId == holderId);
        }


        public Holder GetHolderByLoggedUser(string loggedUser)
        {
            var user = _context.ApplicationUsers.Where(x => x.UserName == loggedUser).FirstOrDefault();
            return _context.Holders.Include(h => h.AccountHolders).ThenInclude(h => h.Account).ThenInclude(h=>h.Currency).Where(x => x.VatNumber == user.VatNumber).FirstOrDefault();
        }
    }
}
