namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExternalTransaction")]
    public partial class ExternalTransaction : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime TransactionDate { get; set; }
        public string TransactionId { get; set; }
        public int? UserId { get; set; }
        public int? TransactionTypeId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public int? ResponseId { get; set; }
        public double Amount { get; set; }
        public int? StatusId { get; set; }

        [ForeignKey("TransactionTypeId")]
        [InverseProperty("ExternalTransactions")]
        public virtual TransactionType TransactionType { get; set; }

        [ForeignKey("StatusId")]
        [InverseProperty("ExternalTransactions")]
        public virtual TransactionStatus TransactionStatus { get; set; }

        //[ForeignKey("UserId")]
        //[InverseProperty("ExternalTransactions")]
        [NotMapped]
        public virtual IDTPUser IDTPUser { get; set; }

        [ForeignKey("SenderId")]
        [InverseProperty("ExternalTransactions")]
        public virtual IDTPUser Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual Beneficiary Receiver { get; set; }

        [ForeignKey("ResponseId")]
        public virtual Response Response { get; set; }

        [ForeignKey("Id")]
        public virtual ExternalNotification ExternalNotification { get; set; }
        public EntityState EntityState { get; set; }
    }
}
