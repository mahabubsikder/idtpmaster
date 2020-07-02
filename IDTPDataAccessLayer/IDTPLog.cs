
using IDTPDataAccessLayer.Interfaces;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace IDTPDataAccessLayer
{
    public class IDTPLog : IIDTPLog
    {
        private readonly string _isVerbose = "false";
        //private IDTPDBContext _context = new IDTPDBContext();

        public IDTPLog()
        {
            //_isVerbose =  ConfigurationManager.AppSettings["Verbose"];
        }
        public void LogUserActivity(int? UserID, string activity, System.Uri pageUrl)
        {
            if (_isVerbose.ToLower(CultureInfo.CurrentCulture) == "true")
            {
                try
                {
                    using (var context = new IDTPDBContext())
                    {
                        SqlParameter param1 = new SqlParameter("@UserId", UserID);

                        SqlParameter param2 = new SqlParameter("@Activity", activity);

                        SqlParameter param3 = new SqlParameter("@PageUrl", pageUrl);

                        context.Database.ExecuteSqlRaw("usp_LogUserActivity @UserId, @Activity, @PageUrl",
                                                      param1, param2, param3);
                    }
                }
                catch (WebException)
                {
                    throw;
                }

            }
        }


        public void LogIDTPError(int? UserID, int errorNumber, string errorContext, string errorMessage, string errorTimeStamp)
        {
            if (_isVerbose.ToLower(CultureInfo.CurrentCulture) == "true")
            {
                using (var context = new IDTPDBContext())
                {
                    SqlParameter param1 = new SqlParameter("@UserID", UserID);

                    SqlParameter param2 = new SqlParameter("@ErrorNumber", errorNumber);

                    SqlParameter param3 = new SqlParameter("@ErrorContex", errorContext);

                    SqlParameter param4 = new SqlParameter("@errorMessage", errorMessage);

                    SqlParameter param5 = new SqlParameter("@errorTimeStamp ", errorTimeStamp);

                    context.Database.ExecuteSqlRaw("usp_LogIDTPError @UserID, @ErrorNumber, @ErrorContex, @errorMessage, @errorTimeStamp",
                                                  param1, param2, param3, param4, param5);
                }
            }
        }


        public List<ActivityLog> GetUserActivityLog(DateTime? logDate)
        {
            IEnumerable<ActivityLog> resultSet;
            using (var context = new IDTPDBContext())
            {
                var LogDate = new SqlParameter("@LogDate", logDate);
                resultSet = context.ActivityLogs.FromSqlRaw<ActivityLog>("usp_GetIDTPUserActivityLog @LogDate", LogDate);
            }
            return resultSet.ToList();


        }

        public List<IDTPErrorLog> GetIDTPErrorLog(DateTime? logDate)
        {
            IEnumerable<IDTPErrorLog> resultSet;
            using (var context = new IDTPDBContext())
            {
                var LogDate = new SqlParameter("@LogDate", logDate);
                resultSet = context.IDTPErrorLogs.FromSqlRaw<IDTPErrorLog>("usp_GetIDTPErrorLog", LogDate);
            }
            return resultSet.ToList();


        }

        //Logging error message from android app for the IDTP system

        public void LogAppErrorInfo(int UserID, string ErrorMessage, string ErrorStackTrace, int ErrorType, DateTime ErrorTimeStamp, string ErrorDeviceInfo)
        {
            if (_isVerbose.ToLower(CultureInfo.CurrentCulture) == "true")
            {
                using (var context = new IDTPDBContext())
                {
                    SqlParameter param1 = new SqlParameter("@UserID", UserID);

                    SqlParameter param2 = new SqlParameter("@ErrorMessage", ErrorMessage);

                    SqlParameter param3 = new SqlParameter("@ErrorStackTrace", ErrorStackTrace);

                    SqlParameter param4 = new SqlParameter("@ErrorType", ErrorType);

                    SqlParameter param5 = new SqlParameter("@ErrorTimeStamp", ErrorTimeStamp);

                    SqlParameter param6 = new SqlParameter("@ErrorDeviceInfo", ErrorDeviceInfo);

                    context.Database.ExecuteSqlRaw("dbo.usp_LogAndroidAppError @UserID, @ErrorMessage, @ErrorStackTrace,@ErrorType,@ErrorTimeStamp,@ErrorDeviceInfo",
                                                  param1, param2, param3, param4, param5, param6);
                    //context.Database.ExecuteSqlCommand("usp_Update_BI_Dashboard_Data");
                }
            }
        }

        public List<IDTPAppErrorLog> GetIDTPAppErrorLog(DateTime? logDate)
        {
            IEnumerable<IDTPAppErrorLog> applogs = null;
            using (var context = new IDTPDBContext())
            {
                var LogDate = new SqlParameter("@LogDate", logDate);
                applogs = context.IDTPAppErrorLogs.FromSqlRaw<IDTPAppErrorLog>("dbo.usp_GetIDTPAppErrorLog @LogDate",
                                                     new SqlParameter("@LogDate", LogDate));
            }
            return applogs.ToList();
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~IDTPLog()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}
