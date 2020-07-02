using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ITransactionRequestLogRepository : IGenericDataRepository<TransactionRequestLog>, IDisposable
    {
    }
}
