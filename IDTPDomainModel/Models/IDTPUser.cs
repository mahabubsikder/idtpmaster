namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IDTPUser")]
    public partial class IDTPUser : EntityAudit, IEntity
    {
        public IDTPUser()
        {
            Transactions = new HashSet<Transaction>();
            Notifications = new HashSet<Notification>();

            ExternalTransactions = new HashSet<ExternalTransaction>();
            ExternalNotifications = new HashSet<ExternalNotification>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string NID { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string AccountNo { get; set; }
        public double Balance { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PIN { get; set; }

       
        [DataType(DataType.Password)]
        public string PINSalt { get; set; }

        [ForeignKey("Id")]
        public virtual EndUserLimit EndUserLimit { get; set; }

        public ICollection<Transaction> Transactions { get; private set; }

        public ICollection<ExternalTransaction> ExternalTransactions { get; private set; }
        public ICollection<Notification> Notifications { get; private set; }

        public ICollection<ExternalNotification> ExternalNotifications { get; private set; }

        public ICollection<Beneficiary> Beneficiaries { get; private set; }

        public EntityState EntityState { get; set; }
    }
}
