using IDTP.Utility;
using IDTPBusinessLayer;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Xml;

namespace BBAPI.Controllers
{
/**
* Description:         This controller class replicates the API of Bangladesh bank.
* Invocation:          No need of invocation. Auto triggered when message is received.
* Implementation Flow:
*                      a. Do settlement for the given bank.
*/
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
        private readonly IBusinessLayer _businessLayer;

        public SettlementController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        /// <summary>
        /// Do settlement for the given bank
        /// </summary>
        /// <returns>PACS.002 XML Response</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpPost]
        public string Post([FromBody] string xml)
        {
            // creating object of CultureInfo 
            CultureInfo cultures = new CultureInfo("en-US");
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                #region data fetched from xml
                string amount, senderBIC, receiverBIC, receiverAccNo = string.Empty;
                //txnId = doc.GetElementsByTagName("TxId").Item(0).InnerText;
                amount = doc.GetElementsByTagName("IntrBkSttlmAmt").Item(0).InnerText;
                senderBIC = doc.GetElementsByTagName("BICFI").Item(0).InnerText;
                receiverBIC = doc.GetElementsByTagName("BICFI").Item(1).InnerText;
                //senderAccNo = doc.GetElementsByTagName("Id").Item(0).InnerText;
                //receiverAccNo = doc.GetElementsByTagName("Id").Item(2).InnerText;
                #endregion

                #region get data from DB
                //var transaction = businessLayer.GetAllTransactions().Where(x => x.TransactionId == txnId).FirstOrDefault();
                //var sender = businessLayer.GetAllBankUsers().Where(x => x.Id == transaction.SenderId).FirstOrDefault();
                //var recevier = businessLayer.GetAllBankUsers().Where(x => x.Id == transaction.ReceiverId).FirstOrDefault();
                //var senderName = businessLayer.GetAllTransactions().SingleOrDefault(m => m.TransactionId == txnId).Sender.AccountName;
                //var receiverName = businessLayer.GetAllTransactions().SingleOrDefault(m => m.TransactionId == txnId).Receiver.AccountName;
                //var senderName = sender.AccountName;
                //var receiverName = recevier.AccountName;

                #endregion

                var bank = _businessLayer.GetBankBySwiftBic(senderBIC);
                var senderName = bank.FinancialInstitution.InstitutionName;
                //var receiverName = "";
                string txnId = "";
                Double.TryParse(amount, NumberStyles.Any, cultures, out double balance);
                BBSettlement settlement = new BBSettlement
                {
                    Id = bank.Id,
                    Balance = balance,
                    ModifiedOn = DateTime.Now,
                    EntityState = EntityState.Modified
                };
                _businessLayer.UpdateBBSettlement(settlement);

                var transactionID = Guid.NewGuid().ToString();
                //ISOComposer composer = new ISOComposer();
                //var pacs002xml = composer.GetDataForPacs002Single(senderBIC, receiverBIC, senderName, receiverName, txnId, amount);                
                var pacs002xml = ISOComposer.GetDataForPacs002Single(senderBIC, txnId, amount, "pacs.009.001.04");

                return pacs002xml.InnerXml;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ex.Message;
            }
        }


    }
}
