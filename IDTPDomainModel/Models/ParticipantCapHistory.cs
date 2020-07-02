namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ParticipantCapHistory")]
    public partial class ParticipantCapHistory : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal CurrentNetDebitCap { get; set; }
        public decimal PreviousNetDebitCap { get; set; }
        public int? FinInstitutionInfoId { get; set; }

        [ForeignKey("FinInstitutionInfoId")]
        [InverseProperty("ParticipantCapHistory")]
        public virtual FinInstitutionInfo FinInstitutionInfo { get; set; }

        public EntityState EntityState { get; set; }
    }
}
