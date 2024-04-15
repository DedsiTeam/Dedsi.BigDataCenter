using Microsoft.Extensions.DependencyInjection;
using Dedsi.BasicData.Core;
using Dedsi.BasicData.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Dedsi.BasicData;

[DependsOn(
    typeof(BasicDataCoreModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class BasicDataInfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BasicDataDbContext>(options =>
        {
            options.AddDefaultRepositories(true);
        });
        
    }
}