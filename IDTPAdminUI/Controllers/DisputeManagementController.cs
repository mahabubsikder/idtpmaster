using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IDTPAdminUI.Helper;
using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
/**
 * Description:This controller class is responsible for lodging dispute and giving response to Disputed Transactions .
 * 
 */
namespace IDTPAdminUI.Controllers
{
    public class DisputeManagementController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBusinessLayer _businessLayer;
        public DisputeManagementController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IBusinessLayer businessLayer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _businessLayer = businessLayer;
        }
        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
        
        /// <summary>
        /// Get the Lodge Participant Complaint Form page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "FinancialInstitute")]
        public IActionResult LodgeParticipantComplaint()
        {
            List<DisputeActionDTO> actions =
                 (from n in _businessLayer.GetAllDisputeActions()
                  select new DisputeActionDTO
                  {
                      Id = n.Id,
                      Name = n.Name
                  }).ToList();
            List<DisputeSeverityDTO> disputeSeverities =
                (from n in _businessLayer.GetAllDisputeSeverity()
                 select new DisputeSeverityDTO
                 {
                     Id = n.Id,
                     Name = n.Name
                 }).ToList();
            
            ViewBag.actionList = actions;
            ViewBag.severityList = disputeSeverities;
            
            return View();
        }

        /// <summary>
        /// Lodge the Dispute request as a result create a dispute in database 
        /// </summary>
        /// <param name="disputeTransactionDTO"></param>
        /// <returns>Redirect to the Home View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FinancialInstitute")]
        public IActionResult LodgeParticipantComplaint([FromForm] DisputeTransactionDTO disputeTransactionDTO)
        {
            try
            {
                DisputeTransactionFund dt = new DisputeTransactionFund();
                if (disputeTransactionDTO != null)
                {
                    dt = new DisputeTransactionFund
                    {
                        Id = disputeTransactionDTO.Id,
                        OriginatorTypeId = 3,
                        ExecutorTypeId = 3,
                        OriginatorId = disputeTransactionDTO.OriginatorId,
                        ExecutorId = disputeTransactionDTO.ExecutorId,
                        DisputeActionId = disputeTransactionDTO.DisputeActionId,
                        DisputeDetail = disputeTransactionDTO.DisputeDetail,
                        DisputeSettledBy = 0,
                        DisputeSettlementStatus = false,
                        DisputeSettlementTime = DateTime.Now,
                        DisputeSettlementType = disputeTransactionDTO.DisputeSettlementType,
                        DisputeSeverityId = disputeTransactionDTO.DisputeSeverityId,
                        DisputeTitle = disputeTransactionDTO.DisputeTitle,
                        DisputeType = disputeTransactionDTO.DisputeType,
                        TransactionSettlementStatusId = 0,
                        ParticipantResponseText = null,
                        ParticipantAction = null,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        EntityState = EntityState.Added
                    };

                    _businessLayer.AddDisputeTransaction(dt);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                //return new JsonResult(new { HttpStatusCode = NotFound(HttpStatusCode.BadRequest), ex.Message });
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all the relevant information of a transaction for lodging a dispute
        /// </summary>
        /// <param name="TransactionId"></param>
        /// <returns>Returns IDTPDisputeDTO as JSON Format</returns>
        [HttpPost]
        [Authorize(Roles = "FinancialInstitute")]
        public async Task<JsonResult> GetTransactionInfoByTransID(string TransactionId)
        {
            var transaction = new IDTPDisputeDTO();
            if (TransactionId != null && !string.IsNullOrEmpty(TransactionId))
            {

                var user = await GetCurrentUser();
                var username = user.UserName;
                var finInstitute = _businessLayer.GetAllFinInstitutionInfos().Where(x => x.LoginId == username).FirstOrDefault();
                var participantId = finInstitute.Id;
                finInstitute.EntityState = EntityState.Unchanged;
                try
                {
                    var transactionMain = _businessLayer.GetAllTransactions().Where(x => x.TransactionId == TransactionId && (x.SenderBankId == participantId || x.ReceiverBankId == participantId)).FirstOrDefault();
                    if(transactionMain == null)
                    {
                        return Json(transaction);
                    }
                    transaction.ID = transactionMain.Id;
                    //transaction.SenderId = _businessLayer.GetBankUserById((int)transactionMain.SenderId).AccountNumber + "@idtp";
                    transaction.SenderId = transactionMain.Sender?.AccountNumber + "@idtp";
                    //transaction.ReceiverId = _businessLayer.GetBankUserById((int)transactionMain.ReceiverId).AccountNumber + "@idtp";
                    transaction.ReceiverId = transactionMain.Receiver?.AccountNumber + "@idtp"; 

                    transaction.TransactionAmount = (double)transactionMain.Amount;
                    transaction.OriginatorId = participantId;
                    transaction.ExecutorId = (string)transactionMain.SenderBankId == participantId ? (string)transactionMain.ReceiverBankId : (string)transactionMain.SenderBankId;
                }
                catch (Exception ex)
                {
                    return null;
                }
                return Json(transaction);
            }
            else
            {
                return Json(transaction);

            }
        }

        /// <summary>
        /// Get the participant response form  
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "FinancialInstitute")]
        public IActionResult ParticipantResponseToDispute()
        {
            return View();
        }

        /// <summary>
        /// update the lodged dispute 
        /// </summary>
        /// <param name="disputeTransactionDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FinancialInstitute")]
        public IActionResult ParticipantResponseToDispute([FromForm] DisputeTransactionDTO disputeTransactionDTO)
        {
            DisputeTransactionFund dt = new DisputeTransactionFund();

            if (disputeTransactionDTO != null)
            {
                dt = _businessLayer.GetDisputeTransactionById(disputeTransactionDTO.Id);

                dt.DisputeAction = null;
                dt.DisputeSeverity = null;
                dt.TransactionFund = null;
                dt.ParticipantAction = disputeTransactionDTO.ParticipantAction;
                dt.ParticipantResponseText = disputeTransactionDTO.ParticipantResponseText;
                dt.DisputeSettlementStatus = (disputeTransactionDTO.ParticipantAction == true ? true : false);
                dt.CreatedOn = DateTime.Now;
                dt.ModifiedOn = DateTime.Now;
                
                dt.EntityState = EntityState.Modified;

                _businessLayer.UpdateDisputeTransaction(dt);
            }
            return RedirectToAction("Index","Home");
        }

        /// <summary>
        /// Get the information of the lodged dispute Transaction for response 
        /// </summary>
        /// <param name="TransactionId"></param>
        /// <returns>Returns ParticipantDisputeResponseDTO as JSON Format</returns>
        [HttpPost]
        [Authorize(Roles = "FinancialInstitute")]
        public JsonResult GetDisputeInfoByTransID(string TransactionId)
        {
            var transaction = new ParticipantDisputeResponseDTO();

            if (TransactionId != null && !string.IsNullOrEmpty(TransactionId))
            {
                
                TransactionFund tf = _businessLayer.GetAllTransactions().Where(x => x.TransactionId == TransactionId).FirstOrDefault();
                if (tf!= null)
                {
                    transaction.Id = tf.Id;
                    transaction.SenderId = tf.Sender?.AccountNumber;
                    transaction.ReceiverId = tf.Receiver?.AccountNumber;
                    //transaction.SenderId = _businessLayer.GetBankUserById((int)tf.SenderId).AccountNumber + "@idtp";
                    transaction.TransactionAmount = (double)tf.Amount;
                    //transaction.ReceiverId = _businessLayer.GetBankUserById((int)tf.ReceiverId).AccountNumber + "@idtp";
                    tf.EntityState = EntityState.Unchanged;
                    DisputeTransactionFund dt = _businessLayer.GetDisputeTransactionById(tf.Id);
                    transaction.DisputeTitle = dt.DisputeTitle;
                    transaction.DisputeDetails = dt.DisputeDetail;
                    transaction.DisputeSeverity = dt.DisputeSeverity.Name;
                    transaction.ParticipantAction = dt.ParticipantAction.ToString();
                    transaction.ParticipantResponse = dt.ParticipantResponseText;
                    dt.EntityState = EntityState.Unchanged;

                }

            }
            return Json(transaction);
        }
    }
}
