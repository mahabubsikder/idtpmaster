using System;

namespace IDTPDomainModel.Models
{

    public abstract class EntityAudit
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //public string ExtendedProperties { get; set; }
        //public byte RecordHash { get; set; }
    }
}
