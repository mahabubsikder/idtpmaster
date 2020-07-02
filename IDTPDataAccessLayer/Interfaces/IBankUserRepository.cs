using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IBankUserRepository : IGenericDataRepository<BankUser>, IDisposable
    {
    }
}
