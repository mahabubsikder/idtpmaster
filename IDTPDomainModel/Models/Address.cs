namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Address")]
    public partial class Address : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public int InstituteType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public EntityState EntityState { get; set; }
    }
}
