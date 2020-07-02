using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDTPAdminUI.Models
{
    public class TransactionViewModel
    {
        public string TransactionId { get; set; }
        public string SenderName { get; set; }
        public string SenderAccountNo { get; set; }
        public string SenderBankName { get; set; }
        public string ReceiverAccountNo { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverBankName { get; set; }
        public string SettlementStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
