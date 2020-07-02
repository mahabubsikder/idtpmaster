using System;

namespace IDTPDataTransferObjects
{
    public partial class TransactionRequestLogDTO
    {
        public int Id { get; set; }
        public string RequestFrom { get; set; }
        public string RequestTo { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
