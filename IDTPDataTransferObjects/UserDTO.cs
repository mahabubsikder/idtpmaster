using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LeaveApprovalSystemDataTransferObjectsCore
{
    public class UserDTO
    {

        public int UserID { get; set; }
       
        public string UserEmployeeID { get; set; }

        public string UserName { get; set; }

        public string EmployeeName { get; set; }

        public string FatherName { get; set; }

        public DateTime DOB { get; set; }

        public DateTime JoiningDate { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public string BloodGroup { get; set; }

        public string Gender { get; set; }

        public string email { get; set; }

        public string MobileNo { get; set; }

        public string MobileId { get; set; }

        public string Address { get; set; }

        public string AccountNo { get; set; }

        public string AccountType { get; set; }

        public string NID { get; set; }

        public string GoogleServerAPIKey { get; set; }

        public string FCMAppRegTokens { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public DateTime Created { get; set; }

        public string FactoryName { get; set; }

        public string FactoryAccountNo { get; set; }

        public string Status { get; set; }

        public float? Balance { get; set; }

        public float? DebitLimit { get; set; }

        public float? CashBackLimit { get; set; }
    }
}
