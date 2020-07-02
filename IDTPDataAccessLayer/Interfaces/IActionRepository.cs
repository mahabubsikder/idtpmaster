using System;
using Action = IDTPDomainModel.Models.Action;

namespace IDTPDataAccessLayer.Interfaces
{
    public interface IActionRepository : IGenericDataRepository<Action>, IDisposable
    {
    }
}
