namespace IDTPDataTransferObjects
{
    public partial class NotificationDTO
    {
        public int Id { get; set; } //Pass Id of Transaction table for this
        public int TransactionTypeId { get; set; }
        public double SenderConcurrentBalance { get; set; }
        public double ReceiverConcurrentBalance { get; set; }
    }
}
