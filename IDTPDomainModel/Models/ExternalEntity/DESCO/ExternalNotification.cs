namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExternalNotification")]
    public partial class ExternalNotification : IEntity
    {
        [Key]
        [ForeignKey("ExternalTransaction")]
        public int Id { get; set; }

        public DateTime NotificationDate { get; set; }


        public virtual ExternalTransaction ExternalTransaction { get; set; }
        public double SenderConcurrentBalance { get; set; }

        public EntityState EntityState { get; set; }

    }
}
