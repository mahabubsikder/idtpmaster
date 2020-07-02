using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IBranchRepository : IGenericDataRepository<Branch>, IDisposable
    {
    }
}
