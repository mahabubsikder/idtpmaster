namespace IDTPDataTransferObjects
{
    public partial class GovtBillPaymentDTO
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public double Amount { get; set; }
        public string ReferenceNumber { get; set; }
        public string BillInfo { get; set; }
        public string OtherInfo { get; set; }
        public int? DeviceLocationInfoId { get; set; }
    }
}
