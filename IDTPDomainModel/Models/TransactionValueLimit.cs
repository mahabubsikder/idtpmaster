namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionValueLimit")]
    public partial class TransactionValueLimit : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Limit { get; set; }

        public int? FinInstitutionInfoId { get; set; }

        public int? TransactionTypeId { get; set; }

        [ForeignKey("TransactionTypeId")]
        [InverseProperty("TransactionValueLimit")]
        public virtual TransactionType TransactionType { get; set; }

        [ForeignKey("FinInstitutionInfoId")]
        [InverseProperty("TransactionValueLimit")]
        public virtual FinInstitutionInfo FinInstitutionInfo { get; set; }

        public EntityState EntityState { get; set; }
    }
}
