using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IMasterTokenRepository : IGenericDataRepository<MasterToken>, IDisposable
    {
    }
}
