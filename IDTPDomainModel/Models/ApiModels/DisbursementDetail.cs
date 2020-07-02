using IDTPDomainModel.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    public partial class DisbursementDetail : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DisbursementId { get; set; }
        public string ReceiverVID { get; set; }
        public double Amount { get; set; }
        [ForeignKey("DisbursementId")]
        [InverseProperty("DisbursementDetails")]
        public virtual Disbursement Disbursement { get; set; }
        public EntityState EntityState { get; set; }
    }
}