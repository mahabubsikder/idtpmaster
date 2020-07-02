using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IPaymentRecordRepository : IGenericDataRepository<PaymentRecord>, IDisposable
    {
    }
}
