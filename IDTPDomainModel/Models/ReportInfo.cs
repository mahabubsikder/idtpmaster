namespace IDTPDomainModel.Models
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReportInfo")]
    public partial class ReportInfo : EntityAudit, IEntity
    {
        public ReportInfo()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string ReportPath { get; set; }
        public string SProcName { get; set; }
        public bool HasFilter { get; set; }

        public EntityState EntityState { get; set; }
    }
}
