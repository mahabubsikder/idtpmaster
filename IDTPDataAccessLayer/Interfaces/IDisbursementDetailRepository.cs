using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IDisbursementDetailRepository : IGenericDataRepository<DisbursementDetail>, IDisposable
    {
    }
}
