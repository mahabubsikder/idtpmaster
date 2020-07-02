using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IEntityTypeRepository : IGenericDataRepository<EntityType>, IDisposable
    {
    }
}
