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
    *                      a. Pays different types of government dues(Ex. Utility bill, Tax).
    */
    [Route("[controller]")]
    [ApiController]
    public class PayGovtDuesController : Controller
    {
        private readonly IBusinessLayer _businessLayer;
        public PayGovtDuesController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Paying different types of government dues(Ex. Utility bill, Tax)
        /// </summary>
        /// <returns>Returns a PACS002 xml</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns the defined XML message on Internal Server Error </returns>
        [HttpPost("/PayGovtDues", Name = "PayGovtDues")]
        [Authorize(Roles = IDTPRoleNames.FinancialInstitute)]
        public string PayGovtDues([FromBody] string xmlData)
        {
            var responseResult = string.Empty;
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                #region data fetched from xml
                string txnId, amountStr, senderBIC, receiverBIC, senderAccNo, receiverAccNo, sendingBankRoutingNo, receivingBankRoutingNo,
                otherInfo;
                txnId = doc.GetElementsByTagName("TxId").Item(0).InnerText;
                amountStr = doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).InnerText;
                senderBIC = doc.GetElementsByTagName("BICFI").Item(0).InnerText;
                receiverBIC = doc.GetElementsByTagName("BICFI").Item(3).InnerText;
                senderAccNo = doc.GetElementsByTagName("Id").Item(0).InnerText;
                receiverAccNo = doc.GetElementsByTagName("Id").Item(8).InnerText;
                sendingBankRoutingNo = doc.GetElementsByTagName("Id").Item(2).InnerText;
                receivingBankRoutingNo = doc.GetElementsByTagName("Id").Item(5).InnerText;
                otherInfo = doc.GetElementsByTagName("Ustrd").Item(0).InnerText;
                DateTime txnDt = DateTime.Now;
                DateTime stlmntDt = DateTime.Now;
                #endregion

                #region data fetched from db for further operation
                var sender = _businessLayer.GetAllIDTPUserEntities().SingleOrDefault(m => m.AccountNo == senderAccNo);
                var receiver = _businessLayer.GetAllIDTPUserEntities().SingleOrDefault(m => m.AccountNo == receiverAccNo);
                //var senderBank = _businessLayer.GetAllBanks().SingleOrDefault(m => m.SwiftBic == senderBIC);
                //var receiverBank = _businessLayer.GetAllBanks().SingleOrDefault(m => m.SwiftBic == receiverBIC);
                #endregion

                /* //update Sending Bank Net Debit Cap
                 var senderInstitutionDebitCap = _businessLayer.GetParticipantDebitCapById(senderBank.Id);
                 senderInstitutionDebitCap.NetDebitCap -= System.Convert.ToDecimal(amount);
                 senderInstitutionDebitCap.EntityState = EntityState.Modified;
                 _businessLayer.UpdateParticipantDebitCap(senderInstitutionDebitCap);*/
                //int deviceLocationInfoId = ParseDeviceLocationInfo.SaveInfo(doc);

                double.TryParse(amountStr, NumberStyles.Any, cultures, out double amount);

                string[] otherInfos = otherInfo.Split(',');
                string[] billInfos = otherInfos[0].Split(':');

                GovtBillPayment govtBillPayment = new GovtBillPayment
                {
                    SenderId = sender.Id,
                    ReceiverId = receiver.Id,
                    Amount = amount,
                    ReferenceNumber = txnId,
                    BillInfo = billInfos[1],
                    OtherInfo = otherInfo,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddGovtBillPayment(govtBillPayment);

                /*//update receiver bank net debit cap
                if (isSameBank)
                {
                    senderInstitutionDebitCap.NetDebitCap += System.Convert.ToDecimal(amount);
                    senderInstitutionDebitCap.EntityState = EntityState.Modified;
                    _businessLayer.UpdateParticipantDebitCap(senderInstitutionDebitCap);
                }
                else
                {
                    var receiverInstitutionDebitCap = _businessLayer.GetParticipantDebitCapById(receiverBank.Id);
                    receiverInstitutionDebitCap.NetDebitCap += System.Convert.ToDecimal(amount);
                    receiverInstitutionDebitCap.EntityState = EntityState.Modified;
                    _businessLayer.UpdateParticipantDebitCap(receiverInstitutionDebitCap);

                }*/

                //ISOComposer composer = new ISOComposer();
                var pacs002xml = ISOComposer.GetDataForPacs002Single(senderBIC, txnId, amountStr, "pacs.008.001.04");
                responseResult = pacs002xml.InnerXml.ToString();

                return responseResult;

            }
            catch (Exception)
            {
                responseResult = IDTPXmlParser.PrepareFailResponse("PayGovtDues");
                return responseResult;
            }
        }
    }
}
