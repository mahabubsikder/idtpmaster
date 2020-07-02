using IDTPDomainModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    public class TransactionMonitoringInfo : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("Transaction")]
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public bool Flagged { get; set; }
        public string Reason { get; set; }
        public string Alert { get; set; }
        public int RequsetFrom { get; set; }
        public string IMEIIP { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int LastTransactionType { get; set; }
        public double LastTransactionAmount { get; set; }
        public DateTime LastTransactionDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Note { get; set; }
        public int? ActionId { get; set; }
        [ForeignKey("ActionId")]
        public virtual Action Action { get; set; }
        public virtual Transaction Transaction { get; set; }
        public EntityState EntityState { get; set; }

    }
}
