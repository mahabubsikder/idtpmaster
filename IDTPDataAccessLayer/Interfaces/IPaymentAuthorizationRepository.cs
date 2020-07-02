using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IPaymentAuthorizationRepository : IGenericDataRepository<PaymentAuthorization>, IDisposable
    {
    }
}
