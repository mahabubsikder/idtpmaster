using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDomainModel.Models
{
    public class TransactionDetailsReport
    {
        public string TransactionId { get; set; }
        public string SendingInstitution { get; set; }
        public string SenderAccountNo { get; set; }
        public string ReceivingInstitution { get; set; }
        public string ReceiverAccountNo { get; set; }
        public string Amount { get; set; }
        public string TransactionDate { get; set; }
        public string SettlementStatus { get; set; }
    }
}
