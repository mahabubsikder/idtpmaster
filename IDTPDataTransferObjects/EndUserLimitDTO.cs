namespace IDTPDataTransferObjects
{
    public partial class EndUserLimitDTO
    {
        public int Id { get; set; }
        public string LoginId { get; set; }
        public int DailyLimitCount { get; set; }
        public decimal DailyLimitAmount { get; set; }
        public int MonthlyLimitCount { get; set; }
        public decimal MonthlyLimitAmount { get; set; }
    }
}
