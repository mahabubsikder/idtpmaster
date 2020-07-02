using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDTPServiceController.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BBSettlementController : Controller
    {

        private readonly IBusinessLayer _businessLayer;
        public BBSettlementController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        [Authorize]
        [HttpPost("/CreateSettlement", Name = "CreateSettlement")]
        public ActionResult CreateSettlement([Bind("Id", "Balance")] SettlementDTO settlementDTO)
        {
            try
            {
                BBSettlement newSettlement = new BBSettlement();
                if (settlementDTO != null)
                {
                    newSettlement = new BBSettlement
                    {
                        Id = settlementDTO.Id,
                        Balance = settlementDTO.Balance,
                        EntityState = EntityState.Added
                    };

                    _businessLayer.AddBBSettlement(newSettlement);
                }
                return Ok(newSettlement);
            }

            catch (Exception ex)
            {
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
                throw new Exception(ex.Message);
            }
        }
    }
}
