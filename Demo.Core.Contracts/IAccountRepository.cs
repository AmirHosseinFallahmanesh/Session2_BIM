using Demo.Core.Entities;
using System.Collections.Generic;
namespace Demo.Core.Contracts
{
    public interface IAccountRepository
    {
         IEnumerable<Account> GetAll();
         Account Get(int id);


        void Update(Account account);
    }
}
