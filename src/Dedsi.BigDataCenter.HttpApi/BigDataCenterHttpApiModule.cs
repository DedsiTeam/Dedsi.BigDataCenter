using Microsoft.Extensions.DependencyInjection;
using Dedsi.BigDataCenter.Core;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Dedsi.BigDataCenter.HttpApi;

[DependsOn(
    typeof(BigDataCenterCoreModule),
    typeof(AbpAspNetCoreMvcModule)
)]
public class BigDataCenterHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BigDataCenterHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}