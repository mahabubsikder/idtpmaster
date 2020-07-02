namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionBill")]
    public partial class TransactionBill : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public string ReceiverName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string SenderBankId { get; set; }
        public string TransactionId { get; set; }
        public string SendingBankRoutingNo { get; set; }
        public string BillReferenceId { get; set; }
        [ForeignKey("SenderId")]
        [InverseProperty("TransactionBills")]
        public virtual BankUser Sender { get; set; }
        [ForeignKey("SenderBankId")]
        [InverseProperty("TransactionBills")]
        public virtual Bank SenderBank { get; set; }
        public int? BillCategoryId { get; set; }

        [ForeignKey("BillCategoryId")]
        [InverseProperty("TransactionBills")]
        public virtual BillCategory BillCategory { get; set; }

        public EntityState EntityState { get; set; }
    }
}
