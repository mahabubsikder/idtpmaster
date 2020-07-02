using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IIDTPUserEntityRepository : IGenericDataRepository<IDTPUserEntity>, IDisposable
    {
    }
}
