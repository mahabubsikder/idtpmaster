using IDTP.Utility;
using IDTPApiService.Helper;
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
    *                      a. Get a QR code for the provided parameters.
    */
    public class QRCodeController : Controller
    {
        /// <summary>
        /// Get a QR code for the provided parameters
        /// </summary>
        /// <returns>Returns the QR code in a defined XML format</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns a defined XML error message on Internal Server Error </returns>
        [HttpPost("/GenerateQRCode", Name = "GenerateQRCode")]
        [AllowAnonymous]
        public string GenerateQRCode([FromBody]string xmlData)
        {

            string response;
            try
            {
                XmlDocument doc = new XmlDocument();
                //ISOComposer composer = new ISOComposer();
                doc.LoadXml(xmlData);
                ParseDeviceLocationInfo.SaveInfo(doc);

                string receiverVirtialId, amountString, pin;
                #region data fetched from xml
                receiverVirtialId = doc.GetElementsByTagName("ReceiverVID").Item(0).Attributes["value"].Value;
                amountString = doc.GetElementsByTagName("TxnAmount").Item(0).Attributes["value"].Value;
                pin = doc.GetElementsByTagName("Data").Item(0).InnerText;
                #endregion

                string imageString = string.Empty, qrText = $"{receiverVirtialId} Amount: {amountString}";
                imageString = IDTPQRCodeGenerator.GenerateQRCode(qrText);

                response = IDTPXmlParser.PrepareSuccessResponse("GenerateQRCodeResponse", "QRCode", imageString);
                return response;
            }

            catch (Exception ex)
            {
                response = IDTPXmlParser.PrepareFailResponse("GenerateQRCodeResponse");
                return response;
            }
        }
    }
}