using IDTPDomainModel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    public partial class Disbursement : EntityAudit, IEntity
    {
        public Disbursement()
        {

            DisbursementDetails = new HashSet<DisbursementDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SenderVID { get; set; }
        public double Amount { get; set; }
        public string ReferenceNo { get; set; }
        public int DeviceLocationInfoId { get; set; }
        public string Criteria { get; set; }

        [ForeignKey("DeviceLocationInfoId")]
        [NotMapped]
        public virtual DeviceLocationInfo DeviceLocationInfo { get; set; }
        public ICollection<DisbursementDetail> DisbursementDetails { get; }
        public EntityState EntityState { get; set; }
    }
}