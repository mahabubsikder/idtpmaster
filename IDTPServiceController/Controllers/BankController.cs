using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPServiceController.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Bank = IDTPDomainModel.Models.Bank;

namespace IDTPServiceController.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BankController : Controller
    {

        private readonly IBusinessLayer _businessLayer;
        public BankController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        [Authorize]
        [HttpPost("/CreateBank", Name = "CreateBank")]
        public ActionResult CreateBank([Bind("Id", "SwiftBic", "SuspenseAccount", "CbaccountNo")] BankDTO bank)
        {
            try
            {
                Bank newBank = new Bank();

                if (bank != null)
                {
                    newBank = new Bank
                    {
                        Id = bank.Id,
                        SwiftBic = bank.SwiftBic,
                        SuspenseAccount = bank.SuspenseAccount,
                        CbaccountNo = bank.CbaccountNo,
                        EntityState = EntityState.Added
                    };
                    _businessLayer.AddBank(newBank);
                }
                return Ok(newBank);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
            }
        }
    }
}
