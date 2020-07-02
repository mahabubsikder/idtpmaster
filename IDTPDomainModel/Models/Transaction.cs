namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Transaction")]
    public partial class Transaction : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionId { get; set; }
        public int? UserId { get; set; }
        ///<summary>
        ///TransactionTypeId 1. Transfer(Send money/Request Money) 2. Payment 3. Cash out
        ///</summary>
        public int? TransactionTypeId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public double Amount { get; set; }

        public int? StatusId { get; set; }

        [ForeignKey("TransactionTypeId")]
        [InverseProperty("Transactions")]
        public virtual TransactionType TransactionType { get; set; }

        [ForeignKey("StatusId")]
        [InverseProperty("Transactions")]
        public virtual TransactionStatus TransactionStatus { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Transactions")]
        public virtual IDTPUser IDTPUser { get; set; }

        [ForeignKey("SenderId")]
        public virtual IDTPUser Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual IDTPUser Receiver { get; set; }

        [ForeignKey("Id")]
        public virtual Notification Notification { get; set; }

        public virtual TransactionMonitoringInfo TransactionMonitoringInfo { get; set; }
        public virtual DisputeTransaction DisputeTransaction { get; set; }
        public EntityState EntityState { get; set; }
    }
}
