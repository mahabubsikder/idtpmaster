using System;

namespace IDTPDataTransferObjects
{
    public class TransactionBillDTO
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string SenderAccNo { get; set; }
        public string ReceiverName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string SenderBankId { get; set; }
        public int SenderBranchId { get; set; }
        public string TransactionId { get; set; }
        public string SendingBankRoutingNo { get; set; }
        public string BillReferenceId { get; set; }

    }
}
