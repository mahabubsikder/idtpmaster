using IDTPDomainModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IDTPDomainModel.Models
{
    public class Branch : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BankId { get; set; }
        public string BranchName { get; set; }
        public string RoutingNumber { get; set; }
        [ForeignKey("BankId")]
        [InverseProperty("Branch")]
        public virtual Bank Bank { get; set; }
        public EntityState EntityState { get; set; }
    }
}
