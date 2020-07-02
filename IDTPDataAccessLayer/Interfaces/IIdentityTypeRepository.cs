using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IIdentityTypeRepository : IGenericDataRepository<IdentityType>, IDisposable
    {
    }
}
