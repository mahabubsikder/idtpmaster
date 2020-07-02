using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IIDTPPermissionRepository : IGenericDataRepository<IDTPPermission>, IDisposable
    {
    }
}
