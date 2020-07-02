namespace IDTPDataTransferObjects
{
    public class ParticipantResponseDTO
    {
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
        public string Disputeaction { get; set; }
        public string Disputeseverity { get; set; }
        public string Responseaction { get; set; }
        public string Responsereason { get; set; }


    }
}
