using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IRoleRepository : IGenericDataRepository<IDTPRole>, IDisposable
    {
    }
}
