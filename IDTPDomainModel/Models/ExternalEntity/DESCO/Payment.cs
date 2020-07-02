namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Payment")]
    public partial class Payment : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionId { get; set; }
        public decimal PaymentAmount { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Payments")]
        public virtual Customer Customer { get; set; }
        public EntityState EntityState { get; set; }
    }
}
