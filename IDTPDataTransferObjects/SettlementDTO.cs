using System;

namespace IDTPDataTransferObjects
{
    public partial class SettlementDTO
    {
        public string Id { get; set; }
        public string BankName { get; set; }
        public string SwiftBic { get; set; }
        public double Balance { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
