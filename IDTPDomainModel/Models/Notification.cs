namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Notification")]
    public partial class Notification : IEntity
    {
        [Key]

        [ForeignKey("Transaction")]
        public int Id { get; set; }
        public DateTime NotificationDate { get; set; }
        public double SenderConcurrentBalance { get; set; }
        public double ReceiverConcurrentBalance { get; set; }
        public virtual Transaction Transaction { get; set; }
        public EntityState EntityState { get; set; }
    }
}
