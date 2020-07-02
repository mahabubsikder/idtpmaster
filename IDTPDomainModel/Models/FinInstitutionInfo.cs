namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using IDTPDomainModel.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FinInstitutionInfo")]
    public partial class FinInstitutionInfo : EntityAudit, IEntity
    {
        public FinInstitutionInfo()
        {
            TransactionValueLimit = new HashSet<TransactionValueLimit>();
            ParticipantCapHistory = new HashSet<ParticipantCapHistory>();

            //Transactions = new HashSet<Transaction>();
            //Notifications = new HashSet<Notification>();

            //ExternalTransactions = new HashSet<ExternalTransaction>();
            //ExternalNotifications = new HashSet<ExternalNotification>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LoginId { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionBranch { get; set; }
        public string TIN { get; set; }
        public string BIN { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonDesignation { get; set; }
        public string ContactPersonOffice { get; set; }
        public string ContactPersonNID { get; set; }
        public string ContactPersonMobile { get; set; }
        public string ContactPersonEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PIN { get; set; }

        
        [DataType(DataType.Password)]
        public string PINSalt { get; set; }
        //public ICollection<ExternalTransaction> ExternalTransactions { get; private set; }
        // public ICollection<ExternalNotification> ExternalNotifications { get; private set; }
        // public ICollection<Beneficiary> Beneficiaries { get; private set; }
        [ForeignKey("Id")]
        public virtual ParticipantCap ParticipantCap { get; set; }
        public ICollection<TransactionValueLimit> TransactionValueLimit { get; }
        public ICollection<ParticipantCapHistory> ParticipantCapHistory { get; }
        public EntityState EntityState { get; set; }
    }
}
