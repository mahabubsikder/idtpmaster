namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DeviceLocationInfo")]
    public partial class DeviceLocationInfo : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string LatLong { get; set; }
        public string Location { get; set; }
        public string IP { get; set; }
        public string IEMEIID { get; set; }
        public string OS { get; set; }
        public string App { get; set; }
        public string Capability { get; set; }
        public EntityState EntityState { get; set; }
    }
}
