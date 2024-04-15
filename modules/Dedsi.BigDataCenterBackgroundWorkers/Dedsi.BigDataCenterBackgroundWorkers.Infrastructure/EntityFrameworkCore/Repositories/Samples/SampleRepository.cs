using Dedsi.BigDataCenterBackgroundWorkers.Samples;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dedsi.BigDataCenterBackgroundWorkers.EntityFrameworkCore.Repositories.Samples;

public class SampleRepository(IDbContextProvider<BigDataCenterBackgroundWorkersDbContext> dbContextProvider)
    : EfCoreRepository<BigDataCenterBackgroundWorkersDbContext, Sample, Guid>(dbContextProvider),
        ISampleRepository
{
    
}