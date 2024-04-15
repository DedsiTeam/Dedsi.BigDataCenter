using Volo.Abp.Application.Services;

namespace Dedsi.BasicData.Core.Applications;

public abstract class BasicDataAppService : ApplicationService
{
    protected BasicDataAppService()
    {
        ObjectMapperContext = typeof(BasicDataCoreModule);
    }
}