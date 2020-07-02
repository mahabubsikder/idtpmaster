using IDTPDomainModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IDTPDomainModel.Models
{
    public class Action : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ActionDescription { get; set; }
        public EntityState EntityState { get; set; }
    }
}
