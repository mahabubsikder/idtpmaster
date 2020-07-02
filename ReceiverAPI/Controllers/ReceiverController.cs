
using IDTP.Utility;
using IDTPBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ReceiverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        private readonly IBusinessLayer _businessLayer;
        public ReceiverController()
        {
            _businessLayer = new BusinessLayer();
        }
        /// <summary>
        /// This method processes the PACS008 XML received from IDTP and process the transaction for Receiver Bank
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns>Returns a PACS002 XML</returns>

        // POST: api/Receiver
        [HttpPost]
        public string Post([FromBody] string xmlData)
        {
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);

            #region data fetched from xml
            string txnId, amount, senderBIC, receiverBIC, receiverAccNo, senderName, receiverName = string.Empty;
            txnId = doc.GetElementsByTagName("TxId").Item(0).InnerText;
            amount = doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).InnerText;
            senderBIC = doc.GetElementsByTagName("BICFI").Item(0).InnerText;
            receiverBIC = doc.GetElementsByTagName("BICFI").Item(3).InnerText;
            receiverAccNo = doc.GetElementsByTagName("Id").Item(8).InnerText;
            senderName = doc.GetElementsByTagName("Nm").Item(0).InnerText;
            receiverName = doc.GetElementsByTagName("Nm").Item(1).InnerText;
            #endregion


            var receiver = _businessLayer.GetAllBankUsers().Where(m => m.AccountNumber == receiverAccNo).FirstOrDefault();
            receiver.Balance += Convert.ToDecimal(amount, cultures);
            receiver.EntityState = IDTPDomainModel.EntityState.Modified;
            _businessLayer.UpdateBankUser(receiver);

            //ISOComposer composer = new ISOComposer();
            //var pacs002xml = composer.GetDataForPacs002Single(senderBIC, receiverBIC, senderName,receiverName, txnId, amount);
            var pacs002xml = ISOComposer.GetDataForPacs002Single(senderBIC, txnId, amount, "pacs.008.001.04");
            XDocument doc02 = new XDocument(pacs002xml);

            //return  doc02.Root.ToString();
            //return Regex.Unescape(pacs002xml.InnerXml);
            return pacs002xml.OuterXml.Replace(@"\", "", StringComparison.CurrentCulture);

        }


    }
}
