using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPServiceController.Helper;
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
    *                      a. Get All End User Limits.
    *                      b. Get End User Limit by Id.
    *                      c. Create End User Limit.
    */


    [Route("[controller]")]
    [ApiController]
    public class EndUserLimitController : Controller
    {
        //private readonly ITransactionRepository _cosmosDbService;
        private readonly IBusinessLayer _businessLayer;
        public EndUserLimitController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;

        }
        
        /// <summary>
        /// Retrieving All End User Limits
        /// </summary>
        /// <remarks>
        ///Implementation: a. Get All End User Limits.
        /// </remarks>
        /// <returns>Returns the full EndUserLimit List </returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        
        [HttpGet("/GetAllEndUserLimits", Name = "GetAllEndUserLimits")]
        public List<System.Dynamic.ExpandoObject> GetAllEndUserLimits()
        {


            var endUserLimits =
               (from n in _businessLayer.GetAllEndUserLimits()
                select new
                {
                    n.Id,
                    n.IDTPUser.LoginId,
                    n.IDTPUser.UserName,
                    n.IDTPUser.NID,
                    n.IDTPUser.Email,
                    n.IDTPUser.ContactNo,
                    n.DailyLimitAmount,
                    n.DailyLimitCount,
                    n.MonthlyLimitAmount,
                    n.MonthlyLimitCount

                }.ToExpando());

            return endUserLimits.ToList();
        }


        ///// <summary>
        ///// Retrieving a EndUserLimit using its EndUserLimit Id
        ///// </summary>
        ///// <remarks>
        ///// Implementation: b. Get EndUserLimit by Id.
        ///// </remarks>
        ///// <param name="id">The Id of the EndUserLimit item to be retrieved</param>
        ///// <returns>Returns the EndUserLimit item with the ID </returns>
        ///// <returns>Returns 200 OK success </returns>
        ///// <returns>Returns 404 Not Found error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>


        [HttpGet("/GetEndUserLimitById/{id}", Name = "GetEndUserLimitById")]
        public System.Dynamic.ExpandoObject GetEndUserLimitById(int id)
        {
            var endUserLimits =
               (from n in _businessLayer.GetAllEndUserLimits().Where(x => x.Id == id)
                select new
                {
                    n.Id,
                    n.IDTPUser.LoginId,
                    n.IDTPUser.UserName,
                    n.IDTPUser.NID,
                    n.IDTPUser.Email,
                    n.IDTPUser.ContactNo,
                    n.DailyLimitAmount,
                    n.DailyLimitCount,
                    n.MonthlyLimitAmount,
                    n.MonthlyLimitCount

                }.ToExpando());

            return endUserLimits.FirstOrDefault();
        }

        ///// <summary>
        ///// Creating a new EndUserLimit Item
        ///// </summary>
        ///// <remarks>
        ///// Implementation: c. Create EndUserLimit.
        ///// </remarks>
        ///// <param name="group"> JSON New EndUserLimit document item</param>
        ///// <returns>Returns the new End User Limit </returns>
        ///// <returns>Returns 201 Created success</returns>
        ///// <returns>Returns 400 Bad Request error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>

        [HttpPost("/CreateEndUserLimit", Name = "CreateEndUserLimit")]
        public ActionResult CreateEndUserLimit([Bind("LoginId,DailyLimitAmount,DailyLimitCount,MonthlyLimitAmount,MonthlyLimitCount")] EndUserLimitDTO endUserLimitDTO)
        {
            try
            {
                EndUserLimit newEndUserLimit = new EndUserLimit();

                if (endUserLimitDTO != null)
                {
                    var user = _businessLayer.GetAllUsers().Where(x => x.LoginId == endUserLimitDTO.LoginId).SingleOrDefault();

                    newEndUserLimit = new EndUserLimit
                    {
                        Id = user.Id,
                        DailyLimitAmount = endUserLimitDTO.DailyLimitAmount,
                        DailyLimitCount = endUserLimitDTO.DailyLimitCount,
                        MonthlyLimitAmount = endUserLimitDTO.MonthlyLimitAmount,
                        MonthlyLimitCount = endUserLimitDTO.MonthlyLimitCount,
                        EntityState = EntityState.Added
                    };
                    _businessLayer.AddEndUserLimit(newEndUserLimit);
                }
                return Ok(newEndUserLimit);

            }

            catch (Exception ex)
            {
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
                throw new Exception(ex.Message);
            }
        }


        /////// <summary>
        /////// Editing an existing End User Limit
        /////// </summary>
        /////// <remarks>
        /////// Implementation: d. Edit End User Limit.
        /////// </remarks>
        /////// <param name="endUserLimit"> JSON New End User Limit document item</param>
        ///// <returns>Returns 201 Created success</returns>
        ///// <returns>Returns 400 Bad Request error</returns>
        ///// <returns>Returns 500 Internal Server Error </returns>


        [HttpPost("/EditEndUserLimit", Name = "EditEndUserLimit")]
        public ActionResult EditEndUserLimit([Bind("Id,DailyLimitAmount,DailyLimitCount,MonthlyLimitAmount,MonthlyLimitCount")] EndUserLimitDTO endUserLimitDTO)
        {
            if (endUserLimitDTO != null)
            {
                EndUserLimit updateEndUserLimit = _businessLayer.GetAllEndUserLimits().Where(x => x.Id == endUserLimitDTO.Id).SingleOrDefault();

                if (updateEndUserLimit != null)
                {
                    updateEndUserLimit.DailyLimitCount = endUserLimitDTO.DailyLimitCount;
                    updateEndUserLimit.DailyLimitAmount = endUserLimitDTO.DailyLimitAmount;
                    updateEndUserLimit.MonthlyLimitCount = endUserLimitDTO.MonthlyLimitCount;
                    updateEndUserLimit.MonthlyLimitAmount = endUserLimitDTO.MonthlyLimitAmount;

                    updateEndUserLimit.EntityState = EntityState.Modified;

                    _businessLayer.UpdateEndUserLimit(updateEndUserLimit);
                    return Ok(updateEndUserLimit);
                }

                else
                {
                    return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), Message = "EndUserLimit Not found" });
                }
            }
            else
            {
                return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), Message = "EndUserLimit Not found" });
            }

        }


        ///// <summary>
        ///// Deleting a End User Limit
        ///// </summary>
        ///// <remarks>
        ///// Implementation: e. Delete End User Limit.
        ///// </remarks>
        ///// <param name="id"> Id of End User Limit to be deleted</param>
        ///// <returns>Delete success message </returns>
        ///// <returns>Returns not found if transaction doesn't exist</returns>
        ///// <returns>Returns 400 Bad Request error</returns>

        [HttpPost("/DeleteEndUserLimit/{id}", Name = "DeleteEndUserLimit")]
        public ActionResult DeleteEndUserLimit(int id)
        {
            EndUserLimit deleteEndUserLimit = _businessLayer.GetAllEndUserLimits().Where(x => x.Id == id).SingleOrDefault();

            if (deleteEndUserLimit != null)
            {
                deleteEndUserLimit.EntityState = EntityState.Deleted;
                _businessLayer.RemoveEndUserLimit(deleteEndUserLimit);
                return Ok(deleteEndUserLimit.Id + " Transaction removed");
            }

            else
            {
                return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), Message = "EndUserLimit not found" });
            }

        }


        ///// <summary>
        ///// Validate User's Transaction Limit
        ///// </summary>
        ///// <remarks>
        ///// Implementation: f. Check User Transaction Limit.
        ///// </remarks>
        ///// <param name="userId"> Id of End User Limit to be checked</param>
        ///// <param name="amount"> Amount of End User's transaction to be checked</param>
        ///// <returns>status code and status message </returns>
        ///// <returns>Returns not found if transaction doesn't exist</returns>
        ///// <returns>Returns 400 Bad Request error</returns>

        //[HttpGet("/CheckEndUserLimitByUserId/{userId},{amount}", Name = "CheckEndUserLimitByUserId")]
        //public ActionResult<dynamic> CheckEndUserLimitByUserId(int userId, decimal amount)
        //{

        //    try
        //    {

        //        var dailySendMoneyList = _businessLayer.GetAllTransactions().Where(x => x.UserId == userId && x.TransactionDate.Date == DateTime.Today);
        //        var monthlySendMoneyList = _businessLayer.GetAllTransactions().Where(x => x.UserId == userId && x.TransactionDate.Month == DateTime.Now.Month);
        //        var dailyBillPaymentList = _businessLayer.GetAllExternalTransactions().Where(x => x.UserId == userId && x.TransactionDate.Date == DateTime.Today);
        //        var monthlyBillPaymentList = _businessLayer.GetAllExternalTransactions().Where(x => x.UserId == userId && x.TransactionDate.Month == DateTime.Now.Month);
        //        IDTPUser user = _businessLayer.GetAllUsers().Where(x => x.Id == userId).FirstOrDefault();
        //        var bankName = user.BankName;
        //        var bankTransactionList1 = _businessLayer.GetAllTransactions().Where(x => x.Sender.BankName == bankName && x.TransactionDate.Date == DateTime.Today);
        //        var bankTransactionList2 = _businessLayer.GetAllExternalTransactions().Where(x => x.Sender.BankName == bankName && x.TransactionDate.Date == DateTime.Today);

        //        int dailyUsedCount = dailySendMoneyList.Count() + dailyBillPaymentList.Count();
        //        decimal dailyUsedAmount = (decimal)dailySendMoneyList.Sum(x => x.Amount) + (decimal)dailyBillPaymentList.Sum(x => x.Amount);
        //        int monthlyUsedCount = monthlySendMoneyList.Count() + monthlyBillPaymentList.Count();
        //        decimal monthlyUsedAmount = (decimal)monthlySendMoneyList.Sum(x => x.Amount) + (decimal)monthlyBillPaymentList.Sum(x => x.Amount);
        //        decimal dailyBankAmount = (decimal)bankTransactionList1.Sum(x => x.Amount); //+ (decimal)bankTransactionList2.Sum(x => x.Amount);

        //        var endUserLimit = _businessLayer.GetEndUserLimitById(userId);
        //        ParticipantCap netDebitCap = _businessLayer.GetAllParticipantDebitCaps().Where(x => x.FinancialInstitution.InstitutionName == bankName).FirstOrDefault();

        //        ///// <remarks>
        //        ///// Status=0 for Limit exceeded 
        //        ///// status=1 for Limit Ok
        //        ///// </remarks>

        //        if (dailyBankAmount+amount > netDebitCap.CurrentNetDebitCap) {
        //            dynamic result = new
        //            {
        //                status = 0,
        //                message = "Your Bank's Net Debit Cap Exceeds" 
        //            };

        //            return result;
        //        }

        //        else if (dailyUsedCount + 1 > endUserLimit.DailyLimitCount)
        //        {
        //            dynamic result = new
        //            {
        //                status = 0,
        //                message = "Your Daily Transction Count Limit is: " + endUserLimit.DailyLimitCount
        //            };

        //            return result;
        //        }

        //        else if (dailyUsedAmount + amount > endUserLimit.DailyLimitAmount)
        //        {
        //            dynamic result = new
        //            {
        //                status = 0,
        //                message = "Your Daily Transction Amount Limit is: " + endUserLimit.DailyLimitAmount
        //            };

        //            return result;
        //        }

        //        else if (monthlyUsedCount + 1 > endUserLimit.MonthlyLimitCount)
        //        {
        //            dynamic result = new
        //            {
        //                status = 0,
        //                message = "Your Monthly Transction Count Limit is: " + endUserLimit.MonthlyLimitCount
        //            };

        //            return result;
        //        }

        //        else if (monthlyUsedAmount + amount > endUserLimit.MonthlyLimitAmount)
        //        {
        //            dynamic result = new
        //            {
        //                status = 0,
        //                message = "Your Monthly Transction Amount Limit is: " + endUserLimit.MonthlyLimitAmount
        //            };

        //            return result;
        //        }

        //        else
        //        {
        //            dynamic result = new
        //            {
        //                status = 1,
        //                message = "Transaction Good To Go"
        //            };

        //            return result;
        //        }
        //    }



        //    catch (Exception ex)
        //    {
        //        return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), Message = ex.Message });
        //    }

        //}

    }

}
