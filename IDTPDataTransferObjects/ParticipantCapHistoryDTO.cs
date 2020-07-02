namespace IDTPDataTransferObjects
{
    public partial class ParticipantCapHistoryDTO
    {
        public int Id { get; set; }
        public decimal CurrentNetDebitCap { get; set; }
        public decimal PreviousNetDebitCap { get; set; }
        public int? FinInstitutionInfoId { get; set; }
    }
}
