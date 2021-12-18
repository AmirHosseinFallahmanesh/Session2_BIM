using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infra.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DemoContext demoContext;

        public AccountRepository(DemoContext demoContext)
        {
            this.demoContext = demoContext;
        }
        public Account Get(int id)
        {
          return  this.demoContext.Accounts.Find(id);
        }

        public IEnumerable<Account> GetAll()
        {
            return this.demoContext.Accounts.ToList();
        }

        public void Update(Account account)
        {
            this.demoContext.Accounts.Update(account);
            this.demoContext.SaveChanges();
        }
    }
}
