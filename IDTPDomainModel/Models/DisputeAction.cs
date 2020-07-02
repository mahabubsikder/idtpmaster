using IDTPDomainModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    [Table("DisputeAction")]
    public partial class DisputeAction : IEntity
    {
        public DisputeAction()
        {
            DisputeTransactionFunds = new HashSet<DisputeTransactionFund>();
            DisputeTransactions = new HashSet<DisputeTransaction>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DisputeTransactionFund> DisputeTransactionFunds { get; }
        public ICollection<DisputeTransaction> DisputeTransactions { get; }
        public EntityState EntityState { get; set; }
    }
}
