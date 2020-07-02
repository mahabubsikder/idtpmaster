using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace IDTPServiceController.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BranchController : Controller
    {

        private readonly IBusinessLayer _businessLayer;
        public BranchController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        [Authorize]
        [HttpPost("/CreateBranch", Name = "CreateBranch")]
        public ActionResult CreateAction([Bind("Id,BankId,BranchName,RoutingNumber")] BranchDTO branch)
        {
            try
            {
                Branch newBranch = new Branch();
                if (branch != null)
                {
                    newBranch = new Branch
                    {
                        BankId = branch.BankId,
                        BranchName = branch.BranchName,
                        RoutingNumber = branch.RoutingNumber,
                        EntityState = EntityState.Added
                    };
                    _businessLayer.AddBranch(newBranch);
                }
                return Ok(newBranch);
            }

            catch (Exception ex)
            {
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
                throw new Exception(ex.Message);
            }
        }
    }
}
