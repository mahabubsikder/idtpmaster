namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SuspenseTransaction")]
    public partial class SuspenseTransaction : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid SuspenseTransactionId { get; set; }
        public string SenderAccountNo { get; set; }
        public string SendingBankId { get; set; }
        public string SendingBankSuspanseAccount { get; set; }
        public decimal? Amount { get; set; }
        public bool? SuspenseStatus { get; set; }
        public DateTime? TransactionInitiatedOn { get; set; }
        public DateTime? SuspenseClearingTime { get; set; }
        public string TransactionId { get; set; }

        [ForeignKey("SendingBankId")]
        [InverseProperty("SuspenseTransactions")]
        public virtual Bank SendingBank { get; set; }

        public EntityState EntityState { get; set; }
    }
}
