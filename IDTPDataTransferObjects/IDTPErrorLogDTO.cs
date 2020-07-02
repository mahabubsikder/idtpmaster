namespace IDTPDataTransferObjects
{
    public class IDTPErrorLogDTO
    {
        public int error_log_key { get; set; }
        public int UserID { get; set; }     
        public int Error_Number { get; set; }
        public string Error_Context { get; set; }
        public string Error_Message { get; set; }
        public string Error_TimeStamp { get; set; }
        //public virtual User User { get; set; }
      

    }
}
