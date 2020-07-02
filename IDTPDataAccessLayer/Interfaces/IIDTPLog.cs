using IDTPDomainModel.Models;
using System;
using System.Collections.Generic;

namespace IDTPDataAccessLayer.Interfaces
{
    public interface IIDTPLog : IDisposable
    {
        void LogUserActivity(int? UserID, string activity, System.Uri pageUrl);
        void LogIDTPError(int? UserID, int errorNumber, string errorContext, string errorMessage, string errorTimeStamp);
        List<ActivityLog> GetUserActivityLog(DateTime? logDate);

        List<IDTPErrorLog> GetIDTPErrorLog(DateTime? logDate);

        void LogAppErrorInfo(int UserID, string ErrorMessage, string ErrorStackTrace, int ErrorType, DateTime ErrorTimeStamp, string ErrorDeviceInfo);
        List<IDTPAppErrorLog> GetIDTPAppErrorLog(DateTime? logDate);
    }
}
