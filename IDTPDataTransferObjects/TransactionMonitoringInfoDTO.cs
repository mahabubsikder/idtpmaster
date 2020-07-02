using System;

namespace IDTPDataTransferObjects
{
    public class TransactionMonitoringInfoDTO
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public bool Flagged { get; set; }
        public string Reason { get; set; }
        public string Alert { get; set; }
        public int RequsetFrom { get; set; }
        public string ImeiIp { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int LastTransactionType { get; set; }
        public string LastTransactionAmount { get; set; }
        public DateTime LastTransactionDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Note { get; set; }
        public int? ActionId { get; set; }
        public string ActionName { get; set; }
        public string SenderName { get; set; }

        public string ReceiverName { get; set; }
        public double Amount { get; set; }
        public string SenderAccountNo { get; set; }
        public string ReceiverAccountNo { get; set; }
        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }
        public string UserContactNo { get; set; }
        public string UserNID { get; set; }
        public string UserEmail { get; set; }
    }
}
