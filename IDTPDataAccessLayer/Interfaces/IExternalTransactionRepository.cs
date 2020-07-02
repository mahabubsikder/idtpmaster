using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IExternalTransactionRepository : IGenericDataRepository<ExternalTransaction>, IDisposable
    {
    }
}
