namespace IDTPDataTransferObjects
{
    public partial class TransactionValueLimitDTO
    {
        public int Id { get; set; }
        public int? FinInstitutionInfoId { get; set; }
        public int? TransactionTypeId { get; set; }
        public decimal Limit { get; set; }
    }
}
