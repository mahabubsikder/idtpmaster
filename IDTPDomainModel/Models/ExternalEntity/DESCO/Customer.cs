namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customer")]
    public partial class Customer : IEntity
    {
        public Customer()
        {
            Payments = new HashSet<Payment>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string ContactNumber { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalDueAmount { get; set; }

        public ICollection<Payment> Payments { get; private set; }
        public EntityState EntityState { get; set; }
    }
}
