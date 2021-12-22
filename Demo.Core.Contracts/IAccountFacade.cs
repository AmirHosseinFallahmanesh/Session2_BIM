using Demo.Core.Entities;
using Demo.Core.Entities.DTO;
using System;
using System.Collections.Generic;

namespace Demo.Core.Contracts
{
    public interface IAccountFacade
    {
         Guid Transfer(int sourceId, int destId, decimal amount);
        IEnumerable<AccountDTO> GetAll();
    }
}
