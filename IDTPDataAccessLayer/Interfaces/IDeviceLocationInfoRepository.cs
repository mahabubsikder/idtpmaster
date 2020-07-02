using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IDeviceLocationInfoRepository : IGenericDataRepository<DeviceLocationInfo>, IDisposable
    {
    }
}
