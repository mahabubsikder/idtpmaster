using System.ComponentModel.DataAnnotations;

namespace IDTPDataTransferObjects
{
    public partial class LoginDTO
    {
        public string UserName { get; set; }
        public string MasterToken { get; set; }
    }
}
