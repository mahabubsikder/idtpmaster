namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionFund")]
    public partial class TransactionFund : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string Narration { get; set; }
        public string SenderBankId { get; set; }
        public string ReceiverBankId { get; set; }
        public string TransactionId { get; set; }
        public string SendingBankRoutingNo { get; set; }
        public string ReceivingBankRoutingNo { get; set; }
        public bool SettlementStatus { get; set; }
        public DateTime SettledOn { get; set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("TransactionFunds")]
        public virtual BankUser Receiver { get; set; }

        [ForeignKey("ReceiverBankId")]
        [InverseProperty("TransactionFunds")]
        public virtual Bank ReceiverBank { get; set; }

        [ForeignKey("SenderId")]
        //[NotMapped]
        public virtual BankUser Sender { get; set; }

        [ForeignKey("SenderBankId")]
        [NotMapped]
        public virtual Bank SenderBank { get; set; }
        public virtual DisputeTransactionFund DisputeTransactionFund { get; set; }
        public EntityState EntityState { get; set; }
    }
}
