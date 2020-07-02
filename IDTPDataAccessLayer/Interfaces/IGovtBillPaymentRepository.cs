using IDTPDomainModel;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IGovtBillPaymentRepository : IGenericDataRepository<GovtBillPayment>, IDisposable
    {
    }
}
