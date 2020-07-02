namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Beneficiary")]
    public partial class Beneficiary : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BeneficiaryType { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryBranch { get; set; }
        public string AccountNumber { get; set; }
        public string ContactNumber { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Beneficiaries")]
        public virtual IDTPUser IDTPUser { get; set; }
        public EntityState EntityState { get; set; }
    }
}
