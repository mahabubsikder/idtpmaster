using IDTP.Utility;
using IDTPApiService.Helper;
using IDTPBusinessLayer;
using IDTPDomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml;

namespace IDTPApiService.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Get an authorization for Payment.
    */

    [Route("[controller]")]
    [ApiController]
    public class PaymentAuthorizationController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public PaymentAuthorizationController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Retrieving an an authorization for Payment
        /// </summary>
        /// <returns>Returns Authorization in a defined XML format</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns a defined XML message on Internal Server Error </returns>
        [HttpPost("/GetPaymentAuthorization", Name = "GetPaymentAuthorization")]
        [Authorize(Roles = IDTPRoleNames.Merchant)]
        public string GetPaymentAuthorization([FromBody] string xmlData)
        {
            string response;
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                #region data fetched from xml
                string senderVirtualIdString, senderInstitutionIdString, receiverVirtualIdString, referenceNumberString, amountString, otherInfo;
                senderVirtualIdString = doc.GetElementsByTagName("SenderVID").Item(0).Attributes["value"].Value;
                senderInstitutionIdString = doc.GetElementsByTagName("SenderInstID").Item(0).Attributes["value"].Value;
                receiverVirtualIdString = doc.GetElementsByTagName("ReceiverVID").Item(0).Attributes["value"].Value;
                referenceNumberString = doc.GetElementsByTagName("ReferenceNo").Item(0).Attributes["value"].Value;
                amountString = doc.GetElementsByTagName("TxnAmount").Item(0).Attributes["value"].Value;
                otherInfo = doc.GetElementsByTagName("OtherInfo").Item(0).Attributes["value"].Value;
                #endregion

                double amount = 0;
                amount = System.Convert.ToDouble(amountString, cultures);
                
                IDTPUserEntity iDTPUserEntitySender = _businessLayer.GetAllIDTPUserEntities().Where(x => x.VirtualId == senderVirtualIdString).FirstOrDefault();
                IDTPUserEntity iDTPUserEntityReceiver = _businessLayer.GetAllIDTPUserEntities().Where(x => x.VirtualId == receiverVirtualIdString).FirstOrDefault();
                bool status = false;
               
                // TODO: we will add payment authorization rules validation here
                if (iDTPUserEntitySender != null && iDTPUserEntityReceiver != null)
                {
                    response = IDTPXmlParser.PrepareSuccessResponse("PaymentAuthorizationResponse", "ReferenceNumber", referenceNumberString);
                    status = true;
                }
                else
                {
                    response = IDTPXmlParser.PrepareFailResponse("PaymentAuthorizationResponse");
                    status = false;
                }
                PaymentAuthorization paymentAuthorization = new PaymentAuthorization
                {
                    SenderId = iDTPUserEntitySender.Id,
                    ReceiverId = iDTPUserEntityReceiver.Id,
                    Amount = amount,
                    Status = status,
                    OtherInfo = otherInfo,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddPaymentAuthorization(paymentAuthorization);
                return response;
            }

            catch (Exception)
            {
                response = IDTPXmlParser.PrepareFailResponse("PaymentAuthorizationResponse");
                return response;
            }
        }
    }
}
