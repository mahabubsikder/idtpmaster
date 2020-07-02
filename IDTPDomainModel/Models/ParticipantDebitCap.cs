namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ParticipantDebitCap")]
    public partial class ParticipantDebitCap : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("FinancialInstitution")]
        public string Id { get; set; }
        public decimal CurrentNetDebitCap { get; set; }
        public decimal ActualDebitCap { get; set; }
        public bool SettlementStatus { get; set; }
        public virtual FinancialInstitution FinancialInstitution { get; set; }
        public EntityState EntityState { get; set; }
    }
}
