using IDTPDomainModel.Interfaces;
using System.Collections.Generic;
namespace IDTPDomainModel.Models
{
    public class BankUser : EntityAudit, IEntity
    {
        public BankUser()
        {
            TransactionFunds = new HashSet<TransactionFund>();
            TransactionBills = new HashSet<TransactionBill>();
        }

        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string ContactNo { get; set; }
        public decimal? Balance { get; set; }
        public EntityState EntityState { get; set; }
        public virtual ICollection<TransactionFund> TransactionFunds { get; }
        public virtual ICollection<TransactionBill> TransactionBills { get; }
    }
}
