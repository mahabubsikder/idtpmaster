using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ITransactionValueLimitRepository : IGenericDataRepository<TransactionValueLimit>, IDisposable
    {
    }
}
