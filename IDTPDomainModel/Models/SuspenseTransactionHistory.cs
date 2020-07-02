using IDTPDomainModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IDTPDomainModel.Models
{

    public class SuspenseTransactionHistory : EntityAudit, IEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid SuspenseTransactionId { get; set; }
        public string SenderAccountNo { get; set; }
        public int? SendingBankId { get; set; }
        public string SendingBankSuspanseAccount { get; set; }
        public decimal? Amount { get; set; }
        public bool? SuspenseStatus { get; set; }
        public DateTime? TransactionInitiatedOn { get; set; }
        public DateTime? SuspenseClearingTime { get; set; }
        public string TransactionId { get; set; }
        public EntityState EntityState { get; set; }
    }

}

