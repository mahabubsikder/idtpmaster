using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPServiceController.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace IDTPServiceController.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Get All ParticipantCaps.
    *                      b. Get ParticipantCap by Id.
    *                      c. Create ParticipantCap.
    *                      d. Edit ParticipantCap.
    *                      e. Delete ParticipantCap.
    *                      f. UpdateAllNetDebitCaps.
    */


    [Route("[controller]")]
    [ApiController]
    public class ParticipantDebitCapController : Controller
    {
        //private readonly ITransactionRepository _cosmosDbService;
        private readonly IBusinessLayer _businessLayer;
        public ParticipantDebitCapController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;

        }

        ///// <summary>
        ///// Creating a new ParticipantCap Item
        ///// </summary>
        ///// <remarks>
        ///// Implementation: c. CreateParticipantCap.
        ///// </remarks>
        ///// <param name="participantCap"> JSON New ParticipantCap document item</param>
        ///// <returns>Returns the new ParticipantCap </returns>
        ///// <returns>Returns 201 Created success</returns>
        ///// <returns>Returns 400 Bad Request error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>
        [Authorize]
        [HttpPost("/CreateParticipantDebitCapLimit", Name = "CreateParticipantDebitCapLimit")]
        public ActionResult CreateParticipantDebitCap([Bind("Id, NetDebitCap")] ParticipantDebitCapDTO participantDebitCapDTO)
        {
            try
            {
                ParticipantDebitCap newParticipantDebitCap = new ParticipantDebitCap();

                if (participantDebitCapDTO != null)
                {
                    newParticipantDebitCap = new ParticipantDebitCap
                    {
                        Id = participantDebitCapDTO.Id,
                        CurrentNetDebitCap = participantDebitCapDTO.NetDebitCap,
                        SettlementStatus = participantDebitCapDTO.SettlementStatus,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        EntityState = EntityState.Added
                    };
                    _businessLayer.AddParticipantDebitCap(newParticipantDebitCap);
                }
                return Ok(newParticipantDebitCap);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
            }
        }

    }

}
