namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GovernmentInstitution")]
    public partial class GovernmentInstitution : EntityAudit, IEntity
    {
        public GovernmentInstitution()
        {

        }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string LoginId { get; set; }
        public string Name { get; set; }
        public string BIN { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string ContactNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonOffice { get; set; }
        public string ContactPersonNID { get; set; }
        public string ContactPersonMobile { get; set; }
        public string ContactPersonEmail { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public EntityState EntityState { get; set; }
    }
}
