namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IDTPUserEntity")]
    public partial class IDTPUserEntity : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdentityTypeId { get; set; }
        public int? EntityTypeId { get; set; }
        public string InstitutionId { get; set; }
        public string AccountNo { get; set; }
        public string VirtualId { get; set; }
        public string NidTinBin { get; set; }
        [DataType(DataType.Password)]
        public string Secret { get; set; }
        [DataType(DataType.Password)]
        public string SecretSalt { get; set; }
        public int? DeviceLocationInfoId { get; set; }

        [ForeignKey("IdentityTypeId")]
        [InverseProperty("IDTPUserEntities")]
        public virtual IdentityType IdentityType { get; set; }

        [ForeignKey("EntityTypeId")]
        [InverseProperty("IDTPUserEntities")]
        public virtual EntityType EntityType { get; set; }

        [ForeignKey("DeviceLocationInfoId")]
        [NotMapped]
        public virtual DeviceLocationInfo DeviceLocationInfo { get; set; }

        public EntityState EntityState { get; set; }
    }
}
