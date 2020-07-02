namespace SenderUI.Models
{
    public class TransferFundRequest
    {
        public string SenderBankID { get; set; }
        public string SenderID { get; set; }
        public string ReceiverBankID { get; set; }
        public string ReceiverID { get; set; }
        public string ReferenceID { get; set; }
        public decimal Amount { get; set; }
    }
}
