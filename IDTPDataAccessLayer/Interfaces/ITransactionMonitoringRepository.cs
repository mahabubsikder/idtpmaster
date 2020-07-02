using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ITransactionMonitoringRepository : IGenericDataRepository<TransactionMonitoringInfo>, IDisposable
    {
    }
}
