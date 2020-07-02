namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransferFund")]
    public partial class TransferFund : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string Narration { get; set; }
        public int? SenderBankId { get; set; }
        public int? ReceiverBankId { get; set; }
        public string TransactionId { get; set; }
        public string SendingBankRoutingNo { get; set; }
        public string ReceivingBankRoutingNo { get; set; }
        public int? DeviceLocationInfoId { get; set; }
        [ForeignKey("ReceiverId")]
        [NotMapped]
        public virtual BankUser Receiver { get; set; }
        [ForeignKey("ReceiverBankId")]
        [NotMapped]
        public virtual Bank ReceiverBank { get; set; }
        [ForeignKey("SenderId")]
        [NotMapped]
        public virtual BankUser Sender { get; set; }
        [ForeignKey("SenderBankId")]
        [NotMapped]
        public virtual Bank SenderBank { get; set; }

        [ForeignKey("DeviceLocationInfoId")]
        [NotMapped]
        public virtual DeviceLocationInfo DeviceLocationInfo { get; set; }
        public EntityState EntityState { get; set; }
    }
}
