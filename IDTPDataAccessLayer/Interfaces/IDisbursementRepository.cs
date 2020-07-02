using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IDisbursementRepository : IGenericDataRepository<Disbursement>, IDisposable
    {
    }
}
