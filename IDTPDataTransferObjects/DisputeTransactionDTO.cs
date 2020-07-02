using System;

namespace IDTPDataTransferObjects
{
    public partial class DisputeTransactionDTO
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public int? OriginatorTypeId { get; set; }
        public string OriginatorType { get; set; }
        public string OriginatorId { get; set; }
        public string OriginatorName { get; set; }
        public int? ExecutorTypeId { get; set; }
        public string ExecutorType { get; set; }
        public string ExecutorId { get; set; }
        public string ExecutorName { get; set; }
        public string TransactionType { get; set; }
        public double TransactionAmout { get; set; }
        public int? TransactionSettlementStatusId { get; set; } // this column is suppossed to be with transaction table
        public string TransactionSettlementStatusName { get; set; }

        public string DisputeSettlementType { get; set; }
        public DateTime DisputeSettlementTime { get; set; }
        public bool? DisputeSettlementStatus { get; set; } //default = 0 = unsettled, 1 = settled
        public int? DisputeSeverityId { get; set; }
        public string DisputeSeverityName { get; set; }

        public int? DisputeSettledBy { get; set; }
        public string DisputeSettledByName { get; set; }

        public string DisputeTitle { get; set; }
        public string DisputeType { get; set; }
        public string DisputeDetail { get; set; }
        public int? DisputeActionId { get; set; }
        public string DisputeActionName { get; set; }
        public bool? ParticipantAction { get; set; }
        public string ParticipantResponseText { get; set; }
    }
}
