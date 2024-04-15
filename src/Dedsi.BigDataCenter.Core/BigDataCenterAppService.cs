using Volo.Abp.Application.Services;

namespace Dedsi.BigDataCenter.Core.Applications;

public abstract class BigDataCenterAppService : ApplicationService
{
    protected BigDataCenterAppService()
    {
        ObjectMapperContext = typeof(BigDataCenterCoreModule);
    }
}