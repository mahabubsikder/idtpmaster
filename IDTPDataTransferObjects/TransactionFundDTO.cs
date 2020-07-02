using System;

namespace IDTPDataTransferObjects
{
    public class TransactionFundDTO
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string Narration { get; set; }
        public string SenderBankId { get; set; }
        public string ReceiverBankId { get; set; }
        public string TransactionId { get; set; }
        public string SendingBankRoutingNo { get; set; }
        public string ReceivingBankRoutingNo { get; set; }
        public string SenderAccNo { get; set; }
        public string ReceiverAccNo { get; set; }
        public int? SenderBranchId { get; set; }
        public int? ReceiverBranchId { get; set; }
        public string Purpose { get; set; }

    }
}
