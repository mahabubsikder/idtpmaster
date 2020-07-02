using IDTPDomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IDTPDomainModel.Models
{
    public class MasterToken : EntityAudit, IEntity
    {
        public MasterToken()
        {
                        
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AppName { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiryDate { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public EntityState EntityState { get; set; }
    }
}
