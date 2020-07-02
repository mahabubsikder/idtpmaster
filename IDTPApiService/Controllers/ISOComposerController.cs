using IDTP.Utility;
using IDTPApiService.Helper;
using IDTPBusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml;

namespace IDTPApiService.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Get PAIN013 XML with provided parameters.
    */
    [Route("[controller]")]
    [ApiController]
    public class ISOComposerController : Controller
    {

       
        public ISOComposerController()
        {
            
        }

        /// <summary>
        /// Get PAIN013 XML with provided parameters.
        /// </summary>
        /// <returns>Returns the PAIN013 XML response</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpGet("/GetPAIN013", Name = "GetPAIN013")]
        [Authorize(Roles = IDTPRoleNames.Merchant)]
        public string GetPAIN013(string transactionId, string initiatorName, string initiatorId, string debtorName,
            string debtorId, string debtorAccount, string debtorAgentBIC, string debtorAgentName, string instructedAmount, string creditorAgentBIC,
            string creditorAgentName, string creditorName, string creditorId, string creditorAccount)
        {

            string response;
            try
            {
                //ISOComposer composer = new ISOComposer();
                XmlDocument xmlDocument = ISOComposer.GetDataForPAIN013(transactionId, initiatorName, initiatorId, debtorName, debtorId,
                    debtorAccount, debtorAgentBIC, debtorAgentName, instructedAmount, creditorAgentBIC, creditorAgentName,
                    creditorName, creditorId, creditorAccount);

                response = xmlDocument.InnerXml.ToString();

                return response;
            }

            catch (WebException)
            {
                response = IDTPXmlParser.PrepareFailResponse("PAIN013");
                return response;
            }
        }
    }
}
