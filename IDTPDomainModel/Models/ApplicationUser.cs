using IDTPDomainModel.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDTPDomainModel.Models
{
    [Table("ApplicationUsers")]
    public partial class ApplicationUser : IdentityUser, IEntity
    {
        public string SecretSalt { get; set; }
        [ForeignKey("Id")]
        public virtual FinancialInstitution FinancialInstitution { get; set; }
        [ForeignKey("Id")]
        public virtual GovernmentInstitution GovernmentInstitution { get; set; }
        [ForeignKey("Id")]
        public virtual Business Business { get; set; }
        [ForeignKey("Id")]
        public virtual IDTPUserAdmin IDTPUserAdmin { get; set; }
        [ForeignKey("Id")]
        public virtual Address Address { get; set; }
        public EntityState EntityState { get; set; }
    }
}
