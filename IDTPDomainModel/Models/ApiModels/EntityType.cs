namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EntityType")]
    public partial class EntityType : EntityAudit, IEntity
    {
        public EntityType()
        {
            IDTPUserEntities = new HashSet<IDTPUserEntity>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<IDTPUserEntity> IDTPUserEntities { get; private set; }
        public EntityState EntityState { get; set; }
    }
}
