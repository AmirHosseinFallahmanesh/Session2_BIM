using Demo.Core.Entities;
using System;
namespace Demo.Core.Contracts
{
    public interface IAccountFacade
    {
         Guid Transfer(int sourceId, int destId, decimal amount);
       
    }
}
