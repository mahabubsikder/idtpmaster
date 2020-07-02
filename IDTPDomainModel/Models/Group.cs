namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Group")]
    public partial class Group : IEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }


        public EntityState EntityState { get; set; }
    }
}
