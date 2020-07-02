namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DBLog")]
    public partial class DBLog : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Message { get; set; }
        public EntityState EntityState { get; set; }
    }
}
