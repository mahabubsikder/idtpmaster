using System;

namespace IDTPDataTransferObjectsCore
{
    public class IDTPAppErrorLogDTO
    {
        public int UserID { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }

        public int ErrorType { get; set; }
        public DateTime ErrorTimeStamp { get; set; }
        public string ErrorDeviceInfo { get; set; }
    }
}