using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ITransactionStatusRepository : IGenericDataRepository<TransactionStatus>, IDisposable
    {
    }
}
