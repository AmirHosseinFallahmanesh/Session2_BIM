using System;
using System.Collections.Generic;
using Demo.Core.Contracts;
using Demo.Core.Entities.DTO;
using EndpointAPI.Model;
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
        public IActionResult GetAll()
        {
            ResponceViewModel<IEnumerable<AccountDTO>> model =
                new ResponceViewModel<IEnumerable<AccountDTO>>();

            try
            {
                model.Data= accountFacade.GetAll();
                model.StatusCode = 200;
                
            }
            catch (Exception ex)
            {

                model.Errors.Add(ex.Message);
                model.IsSuccess = false;
                model.StatusCode = 400;
                return BadRequest(model);
            }
            return Ok(model);


        }



        [HttpPost]
        public IActionResult Post(TransferDTO dto)
        {
            ResponceViewModel<Guid> model = new ResponceViewModel<Guid>();
            try
            {
               
                model.Data = accountFacade.Transfer(dto.sourceId, dto.destId, dto.balance);
                model.StatusCode = 201;
                return Created($"api/account/{model.Data}", model);
            }
            catch (Exception ex)
            {
                model.Errors.Add(ex.Message);
                model.IsSuccess = false;
                model.StatusCode = 400;
                return BadRequest(model);
            }
           
         
        }
    }
}