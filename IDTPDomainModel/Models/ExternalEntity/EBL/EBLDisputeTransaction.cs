using IDTPDomainModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models.ExternalEntity.EBL
{
    [Table("EBLDisputeTransaction")]
    public partial class EBLDisputeTransaction : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("Transaction")]
        public int Id { get; set; }
        public int? OriginatorTypeId { get; set; }
        public int? OriginatorId { get; set; }
        public int? ExecutorTypeId { get; set; }
        public int? ExecutorId { get; set; }

        public int? TransactionSettlementStatusId { get; set; } // this column is suppossed to be with transaction table

        public string DisputeSettlementType { get; set; }
        public DateTime DisputeSettlementTime { get; set; }
        public bool? DisputeSettlementStatus { get; set; } //default = 0 = unsettled, 1 = settled
        public int? DisputeSeverityId { get; set; }
        public int? DisputeSettledBy { get; set; }
        public string DisputeTitle { get; set; }
        public string DisputeType { get; set; }
        public string DisputeDetail { get; set; }
        public int? DisputeActionId { get; set; }

        [ForeignKey("DisputeActionId")]
        [InverseProperty("EBLDisputeTransactions")]
        public virtual DisputeAction DisputeAction { get; set; }
        public bool? ParticipantAction { get; set; } //null = nothing, accept = 1, reject = 0
        public string ParticipantResponseText { get; set; }
        public virtual Transaction Transaction { get; set; }

        [ForeignKey("DisputeSeverityId")]
        [InverseProperty("EBLDisputeTransactions")]
        public virtual DisputeSeverity DisputeSeverity { get; set; } //Dispute Severity
        public EntityState EntityState { get; set; }
    }
}
