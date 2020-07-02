namespace IDTPDataTransferObjects
{
    public partial class BankUserDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string ContactNo { get; set; }
        public decimal? Balance { get; set; }

    }
}
