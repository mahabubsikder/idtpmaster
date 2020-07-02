namespace SenderUI.Models
{
    public class TransferFund
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int SenderBankId { get; set; }
        //public string SenderBankName { get; set; }
        public int SenderBranchId { get; set; }
        public string SenderAccNo { get; set; }
        //public string SenderAccName { get; set; }
        public int ReceiverBankId { get; set; }
        //public string ReceiverBankName { get; set; }
        public int ReceiverBranchId { get; set; }
        public string ReceiverAccNo { get; set; }
        //public string ReceiverAccName { get; set; }
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
    }
}
