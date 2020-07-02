namespace IDTPDataTransferObjects
{
    public class LodgeParticipantComplaintDTO
    {
        public int Id { get; set; }
        public string Transactionid { get; set; }
        public string Senderaccountno { get; set; }
        public string Senderaccountname { get; set; }
        public string Receiveraccountno { get; set; }
        public string Receiveraccountname { get; set; }
        public int? Transactionamount { get; set; }
        public string Settlementstatus { get; set; }
        public string Disputetitle { get; set; }
        public string Disputetype { get; set; }
        public string Disputedetails { get; set; }
        public int Disputeaction { get; set; }
        public int Disputeseverity { get; set; }

    }
}
