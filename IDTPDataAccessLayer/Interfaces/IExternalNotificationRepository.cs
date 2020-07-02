using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IExternalNotificationRepository : IGenericDataRepository<ExternalNotification>, IDisposable
    {
    }
}
