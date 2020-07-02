using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ITransactionFundRepository : IGenericDataRepository<TransactionFund>, IDisposable
    {
    }
}
