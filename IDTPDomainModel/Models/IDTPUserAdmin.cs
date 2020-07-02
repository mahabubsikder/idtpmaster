namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IDTPUserAdmin")]
    public partial class IDTPUserAdmin : EntityAudit, IEntity
    {
        public IDTPUserAdmin()
        {
            //Transactions = new HashSet<Transaction>();         
        }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NID { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        // public ICollection<Transaction> Transactions { get; private set; }
        public EntityState EntityState { get; set; }
    }
}
