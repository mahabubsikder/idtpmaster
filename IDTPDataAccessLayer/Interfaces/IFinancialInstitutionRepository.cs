using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IFinancialInstitutionRepository : IGenericDataRepository<FinancialInstitution>, IDisposable
    {
    }
}
