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
    *                      a. Store the payment info provided by the XML data.
    */

    [Route("[controller]")]
    [ApiController]
    public class PaymentRecordController : Controller
    {
        private string response;

        private readonly IBusinessLayer _businessLayer;
        public PaymentRecordController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Store the payment info provided by the XML data
        /// </summary>
        /// <returns>Returns the success message in a defined XML format</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns a defined XML error message on Internal Server Error </returns>
        [HttpPost("/RecordPayment", Name = "RecordPayment")]
        [Authorize(Roles = IDTPRoleNames.FinancialInstitute)]
        public string RecordPayment([FromBody] string xmlData)
        {
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                #region data fetched from xml
                string senderVirtialId, senderInstitution, receiverVirtialId, receiverInstitutionId, referenceNumber, amountString, otherInfo;
                senderVirtialId = doc.GetElementsByTagName("SenderVID").Item(0).Attributes["value"].Value;
                senderInstitution = doc.GetElementsByTagName("SenderInstID").Item(0).Attributes["value"].Value;
                receiverVirtialId = doc.GetElementsByTagName("ReceiverVID").Item(0).Attributes["value"].Value;
                receiverInstitutionId = doc.GetElementsByTagName("ReceiverInstID").Item(0).Attributes["value"].Value;
                amountString = doc.GetElementsByTagName("TxnAmount").Item(0).Attributes["value"].Value;
                referenceNumber = doc.GetElementsByTagName("ReferenceNo").Item(0).Attributes["value"].Value;
                otherInfo = doc.GetElementsByTagName("OtherInfo").Item(0).Attributes["value"].Value;
                #endregion


                int deviceLocationInfoId = ParseDeviceLocationInfo.SaveInfo(doc);


                IDTPUserEntity iDTPUserEntitySender = _businessLayer.GetAllIDTPUserEntities().Where(x => x.VirtualId == senderVirtialId).FirstOrDefault();
                IDTPUserEntity iDTPUserEntityReceiver = _businessLayer.GetAllIDTPUserEntities().Where(x => x.VirtualId == receiverVirtialId).FirstOrDefault();


                double amount = 0;
                amount = System.Convert.ToDouble(amountString, cultures);

                PaymentRecord paymentRecord = new PaymentRecord
                {
                    SenderId = iDTPUserEntitySender.Id,
                    ReceiverId = iDTPUserEntityReceiver.Id,
                    Amount = amount,
                    ReferenceNumber = referenceNumber,
                    OtherInfo = otherInfo,
                    DeviceLocationInfoId = deviceLocationInfoId,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddPaymentRecord(paymentRecord);

                response = IDTPXmlParser.PrepareSuccessResponse("PaymentRecordResponse", "ReferenceNumber", referenceNumber);
                return response;
            }

            catch (Exception)
            {
                response = IDTPXmlParser.PrepareFailResponse("PaymentRecordResponse");
                return response;
            }
        }
    }
}
