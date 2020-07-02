using IDTPDomainModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    public partial class PayeeDetails : EntityAudit, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VID { get; set; }
        public string Name { get; set; }
        public double Basic { get; set; }        
        public double TotalAllowance { get; set; }
        public double TotalDeductions { get; set; }
        public EntityState EntityState { get; set; }
    }
}