using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IMasterTokenDetailRepository : IGenericDataRepository<MasterTokenDetail>, IDisposable
    {
    }
}
