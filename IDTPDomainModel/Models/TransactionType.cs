namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransactionType")]
    public partial class TransactionType : IEntity
    {
        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
            TransactionValueLimit = new HashSet<TransactionValueLimit>();
            ExternalTransactions = new HashSet<ExternalTransaction>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TransactionTypeName { get; set; }
        public string Description { get; set; }

        public ICollection<Transaction> Transactions { get; }
        public ICollection<TransactionValueLimit> TransactionValueLimit { get; }
        public ICollection<ExternalTransaction> ExternalTransactions { get; }
        public EntityState EntityState { get; set; }
    }
}
