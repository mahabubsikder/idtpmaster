namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionStatus")]
    public partial class TransactionStatus : IEntity
    {
        public TransactionStatus()
        {
            Transactions = new HashSet<Transaction>();
            ExternalTransactions = new HashSet<ExternalTransaction>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TransactionStatusName { get; set; }
        public string Description { get; set; }

        public ICollection<Transaction> Transactions { get; }

        public ICollection<ExternalTransaction> ExternalTransactions { get; }
        public EntityState EntityState { get; set; }
    }
}
