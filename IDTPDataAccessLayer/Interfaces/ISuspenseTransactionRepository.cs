using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ISuspenseTransactionRepository : IGenericDataRepository<SuspenseTransaction>, IDisposable
    {
        void RunRawSqlCommand(string sqlCommand);
    }
}
