using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IBeneficiaryRepository : IGenericDataRepository<Beneficiary>, IDisposable
    {
    }
}
