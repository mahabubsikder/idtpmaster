using IDTPDomainModel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    [Table("IDTPErrorLog")]
    public class IDTPErrorLog : IEntity
    {
        [Key]
        public int Errorlogkey { get; set; }
        public int UserID { get; set; }
        public int ErrorNumber { get; set; }
        public string ErrorContext { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorTimeStamp { get; set; }
        //public virtual User User { get; set; }
        public EntityState EntityState { get; set; }

    }
}
