using System;

namespace IDTPDataTransferObjects
{
    public partial class TransferFundDTO
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string Narration { get; set; }
        public int? SenderBankId { get; set; }
        public int? ReceiverBankId { get; set; }
        public string TransactionId { get; set; }
        public string SendingBankRoutingNo { get; set; }
        public string ReceivingBankRoutingNo { get; set; }
        public int? DeviceLocationInfoId { get; set; }
    }
}
