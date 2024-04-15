using Microsoft.Extensions.DependencyInjection;
using Dedsi.BigDataCenter.Core;
using Dedsi.BigDataCenter.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Dedsi.BigDataCenter;

[DependsOn(
    typeof(BigDataCenterCoreModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class BigDataCenterInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BigDataCenterDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
        
    }
}