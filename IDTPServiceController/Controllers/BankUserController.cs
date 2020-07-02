using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BankUser = IDTPDomainModel.Models.BankUser;

namespace IDTPServiceController.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BankUserController : Controller
    {

        private readonly IBusinessLayer _businessLayer;
        public BankUserController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        [Authorize]
        [HttpPost("/CreateBankUser", Name = "CreateBankUser")]
        public ActionResult CreateBankUser([Bind("Id,AccountNumber, AccountName,ContactNo, Balance")] BankUserDTO bankuser)
        {
            try
            {
                BankUser newBankUser = new BankUser();

                if (bankuser != null)
                {
                    newBankUser = new BankUser
                    {
                        Id = bankuser.Id,
                        AccountName = bankuser.AccountName,
                        AccountNumber = bankuser.AccountNumber,
                        ContactNo = bankuser.ContactNo,
                        Balance = bankuser.Balance,
                        EntityState = EntityState.Added
                    };
                    _businessLayer.AddBankUser(newBankUser);
                }
                return Ok(newBankUser);
            }

            catch (Exception ex)
            {
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
                throw new Exception(ex.Message);
            }
        }
    }
}
