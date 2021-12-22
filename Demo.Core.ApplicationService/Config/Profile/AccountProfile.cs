using AutoMapper;
using Demo.Core.Entities;
using Demo.Core.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.ApplicationService.Config.Profiles
{
   public class AccountProfile:Profile
    {

        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>();
        }
    }
}
