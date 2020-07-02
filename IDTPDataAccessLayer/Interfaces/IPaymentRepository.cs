using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IPaymentRepository : IGenericDataRepository<Payment>, IDisposable
    {
    }
}
