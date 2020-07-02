namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GovtBillPayment")]
    public partial class GovtBillPayment : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public double Amount { get; set; }
        public string ReferenceNumber { get; set; }
        public string BillInfo { get; set; }
        public string OtherInfo { get; set; }
        public int? DeviceLocationInfoId { get; set; }
        [ForeignKey("SenderId")]
        [NotMapped]
        public virtual IDTPUserEntity Sender { get; set; }
        [ForeignKey("ReceiverId")]
        [NotMapped]
        public virtual IDTPUserEntity Receiver { get; set; }
        [ForeignKey("DeviceLocationInfoId")]
        [NotMapped]
        public virtual DeviceLocationInfo DeviceLocationInfo { get; set; }
        public EntityState EntityState { get; set; }
    }
}
