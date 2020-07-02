namespace IDTPDataTransferObjects
{
    public partial class BeneficiaryDTO
    {
        public int Id { get; set; }
        public string BeneficiaryType { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryBranch { get; set; }
        public string AccountNumber { get; set; }
        public string ContactNumber { get; set; }
        public int UserId { get; set; }
    }
}
