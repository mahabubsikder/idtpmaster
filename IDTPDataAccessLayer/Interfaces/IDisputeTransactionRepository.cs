using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IDisputeTransactionRepository : IGenericDataRepository<DisputeTransactionFund>, IDisposable
    {
    }
}
