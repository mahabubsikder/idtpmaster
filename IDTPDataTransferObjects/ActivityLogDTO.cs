using System;

namespace IDTPDataTransferObjectsCore
{
    public partial class ActivityLogDTO
    {
       
        public int ActivityLogKey { get; set; }
        
        public int UserID { get; set; }     

        public string Activity { get; set; }

        public string PageUrl { get; set; }

        public DateTime ActivityDate { get; set; }
        
        //public virtual User User { get; set; }
    }
}
