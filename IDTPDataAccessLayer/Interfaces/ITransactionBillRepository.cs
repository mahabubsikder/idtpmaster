using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ITransactionBillRepository : IGenericDataRepository<TransactionBill>, IDisposable
    {
    }
}
