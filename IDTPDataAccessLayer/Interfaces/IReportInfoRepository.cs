using IDTPDomainModel;
using IDTPDomainModel.Models;
using System;


namespace IDTPDataAccessLayer.Interfaces
{
    public interface IReportInfoRepository : IGenericDataRepository<ReportInfo>, IDisposable
    {
    }
}
