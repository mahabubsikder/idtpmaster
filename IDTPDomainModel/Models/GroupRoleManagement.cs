namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GroupRoleManagement")]
    public partial class GroupRoleManagement : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual IDTPRole Role { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        public EntityState EntityState { get; set; }
    }
}
