using AutoMapper;
using Demo.Core.Contracts;
using Demo.Core.Entities;
using Demo.Core.Entities.DTO;
using Demo.Infra.Data;
using System;
using System.Collections.Generic;

namespace Demo.Core.ApplicationService
{
    public class AccountFacade : IAccountFacade
    {
    
        private readonly MyUnitOfWork uow;
        private readonly IMapper mapper;

        public AccountFacade(MyUnitOfWork myUnitOfWork , IMapper mapper)
        {
        
            this.uow = myUnitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            IEnumerable<Account> accounts = uow.AccountRepository.GetAll();
            IEnumerable<AccountDTO> result = mapper.
                  Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(accounts);
            return result;
        }

        public Guid Transfer(int sourceId, int destId, decimal amount)
        {
            Account sourceAccount = uow.AccountRepository.Get(sourceId);
            if (sourceAccount == null)
            {
                throw new NullReferenceException();
            }

            Account destinationAccount = uow.AccountRepository.Get(destId);
            if (destinationAccount == null)
            {
                throw new NullReferenceException();
            }

            if (sourceAccount.Balance < amount)
            {
                throw new InvalidOperationException();
            }

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            Transaction transaction1 = new Transaction();

            sourceAccount.Transactions.Add(transaction1);


            Transaction transaction2 = new Transaction();

            destinationAccount.Transactions.Add(transaction2);

            uow.AccountRepository.Update(sourceAccount);
            uow.AccountRepository.Update(destinationAccount);
            uow.SaveChanges();

            return transaction1.Id;
        }
    }
}
