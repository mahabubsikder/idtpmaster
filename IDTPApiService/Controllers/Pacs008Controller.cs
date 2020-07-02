using IDTP.Utility;
using IDTPApiService.Helper;
using IDTPDataTransferObjects;
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
   *                      a. Get a Pacs008 XML with the provided paramerters.
   */
    [Route("[controller]")]
    [ApiController]
    public class Pacs008Controller : Controller
    {

        public Pacs008Controller()
        {
        }

        /// <summary>
        /// Retrieving a Pacs008 XML with the provided paramerters
        /// </summary>
        /// <returns>Returns a Pacs008 XML</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpPost("/GetPacs008", Name = "GetPacs008")]
        [Authorize(Roles = IDTPRoleNames.Merchant)]
        public string GetPacs008(Pacs008DTO pacs008DTO)
        {

            string response = string.Empty;
            try
            {
                if (pacs008DTO != null)
                {
                    string otherData = string.Empty;

                    /*otherData = "<BillInfo>"+pacs008DTO.BillInfo + "</BillInfo>" +"+"+ "<EntityName>" + pacs008DTO.EntityName + "</EntityName>" + "+" + "<MobileNumber>" + pacs008DTO.MobileNumber + "</MobileNumber>"
                        + "+" + "<LatLong>" + pacs008DTO.LatLong + "</LatLong>"+ "+" + "<Location>" + pacs008DTO.Location+ "</Location>" + "+" + "<IP>" +pacs008DTO.IP + "</IP>" + "+" + "<IEMEIID>" + pacs008DTO.IEMEIID + "</IEMEIID>"
                        + "+" +"<OS>" + pacs008DTO.OS + "</OS>" + "+" + "<App>" + pacs008DTO.App + "</App>" + "+" + "<Capability>" + pacs008DTO.Capability+ "</Capability>";*/
                    /*otherData = pacs008DTO.BillInfo + "-" + pacs008DTO.EntityName + "-" + pacs008DTO.MobileNumber + "-" + pacs008DTO.LatLong + "-" + pacs008DTO.Location + "-" + pacs008DTO.IP
                        + "-" + pacs008DTO.IEMEIID + "-" + pacs008DTO.OS + "-" + pacs008DTO.App + "-" + pacs008DTO.Capability;*/
                    /*otherData ="Bill " +pacs008DTO.BillInfo + "-Entity " + pacs008DTO.EntityName + "-Cell " + pacs008DTO.MobileNumber + "-Latlong " + pacs008DTO.LatLong + "-Location " + pacs008DTO.Location + "-IP" + pacs008DTO.IP
                        + "-" + pacs008DTO.IEMEIID + "-OS " + pacs008DTO.OS + "-App " + pacs008DTO.App + "-Capability " + pacs008DTO.Capability;*/

                    otherData = "BillNo:" + pacs008DTO.BillInfo + ", Cell:" + pacs008DTO.MobileNumber + ", Purpose:" + pacs008DTO.PaymentPurpose;
                    int length = otherData.Length;

                    if (length >= 140)
                    {
                        otherData = otherData.Substring(0, 139);
                    }

                    //ISOComposer composer = new ISOComposer();
                    XmlDocument xmlDocument = ISOComposer.GetPacs008Data(pacs008DTO.SenderBankBIC, pacs008DTO.ReceiverBankBIC, pacs008DTO.SenderName, pacs008DTO.ReceiverName, pacs008DTO.TransactionId,
                        pacs008DTO.SenderAccount, pacs008DTO.SenderBranchRoutingNo, pacs008DTO.SendingBankCBAccount, pacs008DTO.ReceiverBranchRoutingNo, pacs008DTO.ReceivingBankCBAccount,
                        pacs008DTO.ReceiverAccount, pacs008DTO.Amount, otherData);
                    response = xmlDocument.InnerXml.ToString();
                }
                return response;
            }

            catch (Exception)
            {
                response = IDTPXmlParser.PrepareFailResponse("Pacs008");
                return response;
            }

        }
    }
}
