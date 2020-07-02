using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IDBLogRepository : IGenericDataRepository<DBLog>, IDisposable
    {
    }
}
