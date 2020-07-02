namespace IDTPDataTransferObjects
{
    public partial class ResponserDTO
    {
        public int Id { get; set; }
        public int ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public string EntityName { get; set; }
        public string EntityTransactionRef { get; set; }
    }
}
