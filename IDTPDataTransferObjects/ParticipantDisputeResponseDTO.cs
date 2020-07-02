namespace IDTPDataTransferObjects
{
    public partial class ParticipantDisputeResponseDTO
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public double TransactionAmount { get; set; }
        public string DisputeTitle { get; set; }
        public string DisputeType { get; set; }
        public string DisputeDetails { get; set; }
        public string DisputeAction { get; set; }
        public string DisputeSeverity { get; set; }
        public string ParticipantAction { get; set; }
        public string ParticipantResponse { get; set; }
    }
}
