using IDTPDomainModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    [Table("ActivityLog")]
    public partial class ActivityLog : IEntity
    {
        [Key]
        public int ActivityLogKey { get; set; }

        public int UserID { get; set; }

        public string Activity { get; set; }

        public System.Uri PageUrl { get; set; }

        public DateTime ActivityDate { get; set; }

        //public virtual User User { get; set; }

        public EntityState EntityState { get; set; }
    }
}
