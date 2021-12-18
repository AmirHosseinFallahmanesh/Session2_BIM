using Demo.Core.Contracts;
using Demo.Core.Entities;
using System;

namespace Demo.Core.ApplicationService
{
    public class AccountFacade : IAccountFacade
    {
        private readonly IAccountRepository accountRepository;

        public AccountFacade(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public Guid Transfer(int sourceId, int destId,decimal amount)
        {
          Account sourceAccount=  accountRepository.Get(sourceId);
            if (sourceAccount==null)
            {
                throw new NullReferenceException();
            }

            Account destinationAccount = accountRepository.Get(destId);
            if (destinationAccount == null)
            {
                throw new NullReferenceException();
            }

            if (sourceAccount.Balance<amount)
            {
                throw new InvalidOperationException();
            }

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            Transaction transaction1 = new Transaction();
          
            sourceAccount.Transactions.Add(transaction1);


            Transaction transaction2 = new Transaction();
           
            destinationAccount.Transactions.Add(transaction2);

            accountRepository.Update(sourceAccount);
            accountRepository.Update(destinationAccount);

            return transaction1.Id;
        }
    }
}
