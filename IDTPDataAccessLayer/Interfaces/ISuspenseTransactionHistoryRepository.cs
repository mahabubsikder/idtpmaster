using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ISuspenseTransactionHistoryRepository : IGenericDataRepository<SuspenseTransactionHistory>, IDisposable
    {
    }
}
