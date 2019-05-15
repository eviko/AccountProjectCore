using AccountProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountProjectCore.Repository.Interfaces
{
    public interface IHolderRepository : IRepository<Holder>
    {
        IEnumerable<AccountHolder> GetAccountsByAccountHolder(int holderId);
        Holder GetHolderByLoggedUser(string loggedUser);
    }
}
