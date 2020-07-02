namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FinancialInstitution")]
    public partial class FinancialInstitution : EntityAudit, IEntity
    {
        public FinancialInstitution()
        {

        }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string LoginId { get; set; }
        public string InstitutionName { get; set; }
        public string TIN { get; set; }
        public string BIN { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonOffice { get; set; }
        public string ContactPersonNID { get; set; }
        public string ContactPersonMobile { get; set; }
        public string ContactPersonEmail { get; set; }
        public string SwiftCode { get; set; }
        public string VatId { get; set; }
        public int InstitutionType { get; set; }
        public string BBRefId { get; set; }
        public string InstitutionLicenseNumber { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ParticipantDebitCap ParticipantDebitCap { get; set; }

        public virtual Bank Bank { get; set; }

        public EntityState EntityState { get; set; }
    }
}
