using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IBankRepository : IGenericDataRepository<Bank>, IDisposable
    {
    }
}
