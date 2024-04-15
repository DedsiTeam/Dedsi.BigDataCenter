using Volo.Abp.Application.Services;

namespace Dedsi.BigDataCenterBackgroundWorkers.Core.Applications;

public abstract class BigDataCenterBackgroundWorkersAppService : ApplicationService
{
    protected BigDataCenterBackgroundWorkersAppService()
    {
        ObjectMapperContext = typeof(BigDataCenterBackgroundWorkersCoreModule);
    }
}