namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ParticipantCap")]
    public partial class ParticipantCap : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("FinInstitutionInfo")]
        public int Id { get; set; }
        public decimal CurrentNetDebitCap { get; set; }
        public decimal RequestedNetDebitCap { get; set; }
        ///<summary>
        ///Status 0 for done and 1 for hold
        ///</summary>
        public int Status { get; set; }
        public virtual FinInstitutionInfo FinInstitutionInfo { get; set; }
        public EntityState EntityState { get; set; }
    }
}
