using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface INotificationRepository : IGenericDataRepository<Notification>, IDisposable
    {
    }
}
