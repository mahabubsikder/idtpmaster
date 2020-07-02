using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IMerchantRepository : IGenericDataRepository<Business>, IDisposable
    {
    }
}
