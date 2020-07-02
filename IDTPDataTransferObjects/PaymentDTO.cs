using System;

namespace IDTPDataTransferObjects
{
    public partial class PaymentDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CustomerId { get; set; }
    }
}
