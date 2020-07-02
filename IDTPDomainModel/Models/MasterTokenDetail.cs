using IDTPDomainModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IDTPDomainModel.Models
{
    public class MasterTokenDetail : EntityAudit, IEntity
    {
        public MasterTokenDetail()
        {
                        
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MasterTokenId { get; set; }
        public string AllowedIpOrWebsite { get; set; }
        public ApiCallerType ApiCallerType { get; set; }
        [ForeignKey("MasterTokenId")]
        public virtual MasterToken MasterToken { get; set; }
        public EntityState EntityState { get; set; }
    }
}
