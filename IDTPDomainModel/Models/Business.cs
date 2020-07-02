namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Business")]
    public partial class Business : EntityAudit, IEntity
    {
        public Business()
        {

        }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string LoginId { get; set; }
        public string FullName { get; set; }
        public string TIN { get; set; }
        public string BIN { get; set; }
        public string Email { get; set; }
        public string NID { get; set; }
        public string ContactNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public EntityState EntityState { get; set; }
    }
}
