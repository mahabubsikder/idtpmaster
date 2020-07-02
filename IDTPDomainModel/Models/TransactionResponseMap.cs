namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionResponseMap")]
    public partial class TransactionResponseMap : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? TransactionId { get; set; }
        public int? ResponseId { get; set; }

        [ForeignKey("TransactionId")]
        public virtual ExternalTransaction ExternalTransaction { get; set; }


        [ForeignKey("ResponseId")]
        public virtual Response Response { get; set; }
        public EntityState EntityState { get; set; }
    }
}
