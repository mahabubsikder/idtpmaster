namespace IDTPDataTransferObjects
{
    public partial class IDTPUserEntityDTO
    {
        public int Id { get; set; }
        public int? IdentityTypeId { get; set; }
        public int? EntityTypeId { get; set; }
        public string InstitutionId { get; set; }
        public string AccountNo { get; set; }
        public string VirtualId { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int? DeviceLocationInfoId { get; set; }
    }
}
