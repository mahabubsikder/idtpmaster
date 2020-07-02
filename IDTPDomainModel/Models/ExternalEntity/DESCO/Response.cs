namespace IDTPDomainModel
{
    using IDTPDomainModel.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Response")]
    public partial class Response : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public string EntityName { get; set; }
        public string EntityTransactionRef { get; set; }
        public EntityState EntityState { get; set; }
    }
}
