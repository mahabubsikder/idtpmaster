namespace IDTPDataTransferObjects
{
    public class IDTPDisputeDTO
    {

        public int ID { get; set; }
        public string SenderAccountNo { get; set; }
        public string SenderId { get; set; }
        public string SenderAccountName { get; set; }
        public string ReceiverAccountNo { get; set; }
        public string ReceiverId { get; set; }
        public string ReceiverAccountName { get; set; }
        public double TransactionAmount { get; set; }
        public string OriginatorId { get; set; }
        public string ExecutorId { get; set; }

    }
}
