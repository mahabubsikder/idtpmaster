using IDTPDomainModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IDTPDomainModel.Models
{
    public class TransactionRequestLog : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("TransactionRequestLog")]
        public int Id { get; set; }
        public string RequestFrom { get; set; }
        public string RequestTo { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestTime { get; set; }
        public string TransactionId { get; set; }
        public EntityState EntityState { get; set; }
    }
}
