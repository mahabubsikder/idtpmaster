using IDTP.Utility;
using IDTPApiService.Helper;
using IDTPBusinessLayer;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Xml;

namespace IDTPApiService.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Disburse Government Funds.
    *                      b. Disburse Salary of the Employees.
    */
    public class DisbursmentController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public DisbursmentController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Disburse Government Funds.
        /// </summary>
        /// <returns>Returns the defined XML response</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpPost("/DisburseGovtFunds", Name = "DisburseGovtFunds")]
        [Authorize(Roles = IDTPRoleNames.GovernmentInstitute)]
        public string DisburseGovtFunds([FromBody] string xmlData)
        {
            string response, referenceNumber;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                referenceNumber = ProcessAndInsertDisbursment(doc, "Others");
                response = IDTPXmlParser.PrepareSuccessResponse("DisburseGovtFundsResponse", "Refno", referenceNumber);
                return response;
            }

            catch (Exception)
            {
                response = IDTPXmlParser.PrepareFailResponse("DisburseGovtFundsResponse");
                return response;
            }
        }

        /// <summary>
        /// Disburse Salary of the Employees.
        /// </summary>
        /// <returns>Returns the defined XML response</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpPost("/DisburseSalary", Name = "DisburseSalary")]
        [Authorize(Roles = IDTPRoleNames.FinancialInstitute)]
        public string DisburseSalary([FromBody] string xmlData)
        {
            string response, referenceNumber;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                referenceNumber = ProcessAndInsertDisbursment(doc,"Salary");
                response = IDTPXmlParser.PrepareSuccessResponse("DisburseSalaryResponse", "Refno", referenceNumber);
                return response;
            }

            catch (Exception)
            {
                response = IDTPXmlParser.PrepareFailResponse("DisburseSalaryResponse");
                return response;
            }
        }

        [NonAction]
        string ProcessAndInsertDisbursment(XmlDocument doc, string criteria)
        {
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");

            string referenceNumber;
            try
            {

                int deviceLocationInfoId = ParseDeviceLocationInfo.SaveInfo(doc);

                #region data fetched from xml
                string senderVirtialId, amountString;

                senderVirtialId = doc.GetElementsByTagName("SenderVID").Item(0).Attributes["value"].Value;
                amountString = doc.GetElementsByTagName("TxnAmount").Item(0).Attributes["value"].Value;
                referenceNumber = doc.GetElementsByTagName("ReferenceNo").Item(0).Attributes["value"].Value;
                var receiverList = doc.GetElementsByTagName("ReceiverVID");
                #endregion

                double amount;
                amount = 0;

                double.TryParse(amountString, NumberStyles.Any, cultures, out amount);

                Disbursement disbursment = new Disbursement
                {
                    SenderVID = senderVirtialId,
                    Amount = amount,
                    ReferenceNo = referenceNumber,
                    DeviceLocationInfoId = deviceLocationInfoId,
                    Criteria = criteria,
                    CreatedOn = DateTime.Now,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddDisbursment(disbursment);

                List<DisbursementDetail> disbursementDetails = new List<DisbursementDetail>();
                for (int i = 0; i < receiverList.Count; i++)
                {

                    DisbursementDetail disbursementDetail = new DisbursementDetail();

                    amountString = receiverList.Item(i).Attributes["amount"].Value;
                    double.TryParse(amountString, NumberStyles.Any, cultures, out amount);
                    disbursementDetail.ReceiverVID = receiverList.Item(i).Attributes["value"].Value;
                    disbursementDetail.Amount = amount;
                    disbursementDetail.DisbursementId = disbursment.Id;
                    disbursementDetail.EntityState = EntityState.Added;
                    disbursementDetails.Add(disbursementDetail);
                }
                _businessLayer.AddDisbursmentDetail(disbursementDetails.ToArray());

                return referenceNumber;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ex.Message;
            }

        }
    }
}