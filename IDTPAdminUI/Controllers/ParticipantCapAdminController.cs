using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IDTPDataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using IDTPAdminUI.Helper;
using Microsoft.AspNetCore.Authorization;
using IDTPBusinessLayer;
using IDTPDomainModel;
/**
 * Description:         This controller class is responsible for handling net debit cap of participants.
 * 
 */
namespace IDTPAdminUI.Controllers
{
    public class ParticipantCapAdminController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public ParticipantCapAdminController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        [HttpGet]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Shows the view for net debit cap management for individual participant
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ParticipantCapManagement()
        {
            return View();
        }

        /// <summary>
        /// Shows the view for global net debit cap management for participants
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult ParticipantCapManagementAll()
        {
            return View();
        }

        /// <summary>
        /// Method for net debit cap update of individual participant
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult UpdateDebitCap(ParticipantDebitCapDTO participantDebitCapDTO)
        {
            if(participantDebitCapDTO == null)
            {
                return RedirectToAction("ParticipantCapManagement", "ParticipantCapAdmin");
            }
            else
            {
                try
                {
                    
                    ParticipantDebitCap updateParticipantDebitCap = _businessLayer.GetAllParticipantDebitCaps().Where(x => x.Id == participantDebitCapDTO.Id).SingleOrDefault();
                    if (updateParticipantDebitCap != null)
                    {
                        updateParticipantDebitCap.CurrentNetDebitCap = participantDebitCapDTO.NetDebitCap;
                        updateParticipantDebitCap.ActualDebitCap = participantDebitCapDTO.NetDebitCap;
                        updateParticipantDebitCap.SettlementStatus = participantDebitCapDTO.SettlementStatus;
                        updateParticipantDebitCap.ModifiedOn = DateTime.Now;
                        updateParticipantDebitCap.EntityState = EntityState.Modified;

                        _businessLayer.UpdateParticipantDebitCap(updateParticipantDebitCap);
                        //return Ok(updateParticipantDebitCap);
                    }
                }
                catch (WebException)
                {

                }
                TempData["Updated"] = "True";
                return RedirectToAction("ParticipantCapManagement", "ParticipantCapAdmin");
            }
        }

        /// <summary>
        /// Method for net debit cap update of all participants
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult UpdateAllDebitCap(decimal netDebitCap)
        {
            try
            {
                
                List<ParticipantDebitCap> participantDebitCaps = _businessLayer.GetAllParticipantDebitCaps().ToList();

                foreach (ParticipantDebitCap participantDebitCap in participantDebitCaps)
                {
                    participantDebitCap.CurrentNetDebitCap = netDebitCap;
                    participantDebitCap.ActualDebitCap = netDebitCap;
                    participantDebitCap.SettlementStatus = false;
                    participantDebitCap.ModifiedOn = DateTime.Now;
                    participantDebitCap.EntityState = EntityState.Modified;
                }

                _businessLayer.UpdateParticipantDebitCap(participantDebitCaps.ToArray());
            }
            catch (WebException)
            {

            }
            TempData["Updated"] = "True";
            return RedirectToAction("ParticipantCapManagementAll", "ParticipantCapAdmin");
        }

        /// <summary>
        /// Method to get participant's details by LoginId(Ajax Call)
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "IDTPAdmin")]
        public JsonResult GetFinancialInsByLoginId(string loginId)
        {
            var entity = new FinancialInstitution();
            var entityDTO = new FinancialInstitutionDTO();
            try
            {
               
                entity = _businessLayer.GetAllFinInstitutionInfos().Where(x => x.LoginId == loginId).FirstOrDefault();
                if(entity != null)
                {
                    entityDTO.Id = entity.Id;
                    entityDTO.InstitutionName = entity.InstitutionName;

                }

            }
            catch (WebException)
            {

            }
            return Json(entityDTO);

        }

    }
}