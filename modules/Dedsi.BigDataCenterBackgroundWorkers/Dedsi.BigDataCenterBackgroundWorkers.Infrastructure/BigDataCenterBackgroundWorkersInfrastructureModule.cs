using Microsoft.Extensions.DependencyInjection;
using Dedsi.BigDataCenterBackgroundWorkers.Core;
using Dedsi.BigDataCenterBackgroundWorkers.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Dedsi.BigDataCenterBackgroundWorkers;

[DependsOn(
    typeof(BigDataCenterBackgroundWorkersCoreModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class BigDataCenterBackgroundWorkersInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BigDataCenterBackgroundWorkersDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
        
    }
}