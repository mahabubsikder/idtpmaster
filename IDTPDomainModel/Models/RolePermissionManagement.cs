namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RolePermissionManagement")]
    public partial class RolePermissionManagement : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }

        [ForeignKey("RoleId")]
        public virtual IDTPRole Role { get; set; }

        [ForeignKey("PermissionId")]
        public virtual IDTPPermission IDTPPermission { get; set; }
        public EntityState EntityState { get; set; }
    }
}
