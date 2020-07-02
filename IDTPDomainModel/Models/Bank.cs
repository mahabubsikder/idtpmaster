using IDTPDomainModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IDTPDomainModel.Models
{
    public class Bank : EntityAudit, IEntity
    {
        public Bank()
        {

            Branch = new HashSet<Branch>();
            TransactionFunds = new HashSet<TransactionFund>();
            TransactionBills = new HashSet<TransactionBill>();
            SuspenseTransactions = new HashSet<SuspenseTransaction>();
        }
        [Key]
        [ForeignKey("FinancialInstitution")]
        public string Id { get; set; }
        public string SwiftBic { get; set; }
        public string SuspenseAccount { get; set; }
        public string CbaccountNo { get; set; }
        public virtual FinancialInstitution FinancialInstitution { get; set; }

        public EntityState EntityState { get; set; }
        public virtual ICollection<Branch> Branch { get; }
        public virtual ICollection<SuspenseTransaction> SuspenseTransactions { get; }
        public virtual ICollection<TransactionFund> TransactionFunds { get; }
        public virtual ICollection<TransactionBill> TransactionBills { get; }

        public virtual BBSettlement BBSettlements { get; set; }
    }
}
