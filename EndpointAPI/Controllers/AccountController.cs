using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndpointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountFacade accountFacade;

        public AccountController(IAccountFacade accountFacade)
        {
            this.accountFacade = accountFacade;
        }

        [HttpGet]
        public void Get()
        {

        }



        [HttpPost]
        public IActionResult Post(TransferDTO dto)
        {
            return Ok(accountFacade.Transfer(dto.sourceId, dto.destId, dto.balance));
        }
    }
}