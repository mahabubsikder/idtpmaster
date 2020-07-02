namespace IDTPDataTransferObjects
{
    public partial class TransactionDTO
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public int? UserId { get; set; }
        public int? TransactionTypeId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public double Amount { get; set; }
        public int? StatusId { get; set; }

    }
}
