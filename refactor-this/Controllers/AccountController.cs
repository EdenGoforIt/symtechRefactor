using refactor_this.IService;
using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace refactor_this.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            try {
                var account = _accountService.GetById(id);
                if (account == null)
                    return NotFound();
                return Ok(account);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            } 
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            try
            {
                var accounts = _accountService.Get();
                return Ok(accounts);
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            } 
        }
         
        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            //check the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _accountService.UpdateOrCreate(account);
                return Ok();
            }
            catch (Exception e)
            {
                //will think about the best status code for creation failed. 
                //But actually it's better to show the meaningful and readible message to the client
                return BadRequest(e.Message);
            }  
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            //check the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _accountService.UpdateOrCreate(account);
                return Ok();
            }
            catch (Exception e)
            {
                //will think about the best status code for creation failed. 
                //But actually it's better to show the meaningful and readible message to the client
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            //check the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _accountService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                //will think about the best status code for creation failed. 
                //But actually it's better to show the meaningful and readible message to the client
                return BadRequest(e.Message);
            }
        }
    }
}