using Volo.Abp.Domain.Repositories;

namespace Dedsi.BigDataCenterBackgroundWorkers.Samples;

public interface ISampleRepository : IRepository<Sample, Guid>
{
    
}