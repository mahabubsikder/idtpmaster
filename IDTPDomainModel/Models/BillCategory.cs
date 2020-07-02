using IDTPDomainModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel
{
    [Table("BillCategory")]
    public partial class BillCategory : IEntity
    {
        public BillCategory()
        {
            TransactionBills = new HashSet<TransactionBill>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public ICollection<TransactionBill> TransactionBills { get; }
        public EntityState EntityState { get; set; }
    }
}
