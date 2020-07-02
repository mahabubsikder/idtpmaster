using IDTP.Utility;
using IDTPApiService.Helper;
using IDTPBusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Xml;

namespace IDTPApiService.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Get a request declied response from the provided PAIN.013 XML.
    */

    [Route("[controller]")]
    [ApiController]
    public class RTPDeclinedResponse : Controller
    {       
        public RTPDeclinedResponse()
        {
        
        }

        /// <summary>
        /// Get a request declied response from the provided PAIN.013 XML
        /// </summary>
        /// <returns>Returns a PAIN.014 XML</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns a defined XML error message on Internal Server Error </returns>
        [HttpPost("/CreateDeclinedResponse", Name = "CreateDeclinedResponse")]
        [Authorize(Roles = IDTPRoleNames.Merchant)]
        public string CreateDeclinedResponse([FromBody] string xmlData)
        {
            string response;
            try
            {
                XmlDocument doc = new XmlDocument();
                //ISOComposer composer = new ISOComposer();
                doc.LoadXml(xmlData);


                #region data fetched from xml
                string transactionId, initiatorName, initiatorId, debitorAgentName, creditorAgentName, originalPaymentInfoId, debitorAgentBic,
                     debitorAccount, debitorName, transactionAmount, creditorAgentBIC, creditorAccount, creditorName, responseStatus;

                transactionId = doc.GetElementsByTagName("MsgId").Item(0).InnerText;
                initiatorName = doc.GetElementsByTagName("Nm").Item(0).InnerText;
                initiatorId = doc.GetElementsByTagName("Id").Item(1).InnerText;

                originalPaymentInfoId = doc.GetElementsByTagName("PmtInfId").Item(0).InnerText;

                debitorAgentBic = doc.GetElementsByTagName("DbtrAgt").Item(0).InnerXml;
                var tempDoc = new XmlDocument();
                tempDoc.LoadXml(debitorAgentBic);
                debitorAgentBic = tempDoc.GetElementsByTagName("Cd").Item(0).InnerText;
                debitorAgentName = tempDoc.GetElementsByTagName("Nm").Item(0).InnerText;

                debitorAccount = doc.GetElementsByTagName("DbtrAcct").Item(0).InnerXml;
                tempDoc = new XmlDocument();
                tempDoc.LoadXml(debitorAccount);
                debitorAccount = tempDoc.GetElementsByTagName("Id").Item(0).InnerText;

                debitorName = doc.GetElementsByTagName("Dbtr").Item(0).FirstChild.InnerText;
                transactionAmount = doc.GetElementsByTagName("InstdAmt").Item(0).InnerText;

                creditorAgentBIC = doc.GetElementsByTagName("CdtrAgt").Item(0).InnerXml;
                tempDoc = new XmlDocument();
                tempDoc.LoadXml(creditorAgentBIC);
                creditorAgentBIC = tempDoc.GetElementsByTagName("Cd").Item(0).InnerText;
                creditorAgentName = tempDoc.GetElementsByTagName("Nm").Item(0).InnerText;

                creditorAccount = doc.GetElementsByTagName("CdtrAcct").Item(0).InnerXml;
                tempDoc = new XmlDocument();
                tempDoc.LoadXml(creditorAccount);
                creditorAccount = tempDoc.GetElementsByTagName("Id").Item(0).InnerText;

                creditorName = doc.GetElementsByTagName("Cdtr").Item(0).FirstChild.InnerText;
                responseStatus = "RJCT";
                #endregion

                var pain014 = ISOComposer.DeclinedResponsePAIN014(transactionId, initiatorId, initiatorName, debitorAgentBic, debitorAgentName, debitorAccount, debitorName,
                    transactionAmount, creditorAgentBIC, creditorAgentName, creditorAccount, creditorName, responseStatus);

                response = pain014.InnerXml.ToString();

                return response;
            }

            catch (Exception)
            {
                response = IDTPXmlParser.PrepareFailResponse("PAIN013TOPAIN014)");
                return response;
            }
        }
    }
}
