using IDTPDataAccessLayer.Interfaces;
using IDTPDomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace IDTPDataAccessLayer
{
    public class SuspenseTransactionRepository : GenericDataRepository<SuspenseTransaction>, ISuspenseTransactionRepository
    {
        private static IDTPDBContext _context;
        public SuspenseTransactionRepository()
        {
            _context = new IDTPDBContext();
        }
        public void RunRawSqlCommand(string sqlCommand)
        {
            _context.Database.ExecuteSqlRaw(sqlCommand);
            _context.Dispose();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
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
        ~SuspenseTransactionRepository()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public new void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        //rename this method       
        #endregion
    }
}
