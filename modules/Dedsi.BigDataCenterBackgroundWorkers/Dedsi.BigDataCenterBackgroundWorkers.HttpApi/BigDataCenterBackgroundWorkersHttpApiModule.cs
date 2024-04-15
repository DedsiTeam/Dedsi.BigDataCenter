using Microsoft.Extensions.DependencyInjection;
using Dedsi.BigDataCenterBackgroundWorkers.Core;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Dedsi.BigDataCenterBackgroundWorkers.HttpApi;

[DependsOn(
    typeof(BigDataCenterBackgroundWorkersCoreModule),
    typeof(AbpAspNetCoreMvcModule)
)]
public class BigDataCenterBackgroundWorkersHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BigDataCenterBackgroundWorkersHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}