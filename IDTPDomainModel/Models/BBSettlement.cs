
using IDTPDomainModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    public partial class BBSettlement : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("Bank")]
        public string Id { get; set; }
        public double Balance { get; set; }

        public virtual Bank Bank { get; set; }
        public EntityState EntityState { get; set; }
    }
}
