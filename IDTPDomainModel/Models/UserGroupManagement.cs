namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserGroupManagement")]
    public partial class UserGroupManagement : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }


        [ForeignKey("UserId")]
        public virtual IDTPUser IDTPUser { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        public EntityState EntityState { get; set; }
    }
}
