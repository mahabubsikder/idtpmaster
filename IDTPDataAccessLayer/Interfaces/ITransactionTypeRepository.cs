using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ITransactionTypeRepository : IGenericDataRepository<TransactionType>, IDisposable
    {
    }
}
