namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EndUserLimit")]
    public partial class EndUserLimit : EntityAudit, IEntity
    {
        [Key]
        [ForeignKey("IDTPUser")]
        public int Id { get; set; }
        public int DailyLimitCount { get; set; }
        public decimal DailyLimitAmount { get; set; }
        public int MonthlyLimitCount { get; set; }
        public decimal MonthlyLimitAmount { get; set; }
        public virtual IDTPUser IDTPUser { get; set; }
        public EntityState EntityState { get; set; }
    }
}
