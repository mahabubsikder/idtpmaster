namespace IDTPDataTransferObjects
{
    public partial class Pacs008DTO
    {
        public string SenderBankBIC { get; set; }
        public string ReceiverBankBIC { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string TransactionId { get; set; }
        public string SenderAccount { get; set; }
        public string SenderBranchRoutingNo { get; set; }
        public string SendingBankCBAccount { get; set; }
        public string ReceiverBranchRoutingNo { get; set; }
        public string ReceivingBankCBAccount { get; set; }
        public string ReceiverAccount { get; set; }
        public string Amount { get; set; }
        public string PaymentPurpose { get; set; }
        public string BillInfo { get; set; }
        public string EntityName { get; set; }
        public string MobileNumber { get; set; }
        public string LatLong { get; set; }
        public string Location { get; set; }
        public string IP { get; set; }
        public string IEMEIID { get; set; }
        public string OS { get; set; }
        public string App { get; set; }
        public string Capability { get; set; }
    }
}
