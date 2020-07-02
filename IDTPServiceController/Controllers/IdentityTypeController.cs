using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
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
    *                      a. Get All Identity Type.
    *                      b. Create Identity Type.
    *                      c. Delete Identity Type.
    */

    [Route("[controller]")]
    [ApiController]
    public class IdentityTypeController : Controller
    {
        //private readonly IUserRepository _cosmosDbService;
        private readonly IBusinessLayer _businessLayer;
        public IdentityTypeController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        
        ///// <summary>
        ///// Creating a new Identity Type entry
        ///// </summary>
        ///// <remarks>
        ///// Implementation: b. Identity Type.
        ///// </remarks>
        ///// <param name="user"> JSON New Identity Type entry</param>
        ///// <returns>Returns the new Identity Type DTO </returns>
        ///// <returns>Returns 201 Created success</returns>
        ///// <returns>Returns 400 Bad Request error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>
        [Authorize]
        [HttpPost("/CreateIdentityType", Name = "CreateIdentityType")]
        public ActionResult CreateIdentityType([Bind("Id,Type,Value")] IdentityTypeDTO identityTypeDTO)
        {
            try
            {
                IdentityType newIdentityType = new IdentityType();
                if (identityTypeDTO != null)
                {
                    newIdentityType = new IdentityType
                    {
                        Type = identityTypeDTO.Type,
                        EntityState = EntityState.Added
                    };
                    _businessLayer.AddIdentityType(newIdentityType);
                }
                return Ok(newIdentityType);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
            }
        }


        /////// <summary>
        /////// Deleting Existing Identity Type
        /////// </summary>
        /////// <remarks>
        /////// Implementation: c. Delete Identity Type.
        /////// </remarks>
        /////// <param name="id">The Id of the Identity Type entry to be deleted</param>
        ///// <returns>Returns Deleted Identity Type Id</returns>
        ///// <returns>Returns Not found message if IdentityType Not exists</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>
        [Authorize]
        [HttpPost("/DeleteIdentityType/{id}", Name = "DeleteIdentityType")]
        public ActionResult DeleteIdentityType(int id)
        {
            IdentityType deleteIdentityType = _businessLayer.GetAllIdentityTypes().Where(x => x.Id == id).SingleOrDefault();

            if (deleteIdentityType != null)
            {
                deleteIdentityType.EntityState = EntityState.Deleted;
                _businessLayer.RemoveIdentityType(deleteIdentityType);
                return Ok(deleteIdentityType.Id + " IdentityType removed");
            }

            else
            {
                return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), Message = "IdentityType  not found" });
            }

        }
        

    }
}
