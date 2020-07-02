using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface ICustomerRepository : IGenericDataRepository<Customer>, IDisposable
    {
    }
}
