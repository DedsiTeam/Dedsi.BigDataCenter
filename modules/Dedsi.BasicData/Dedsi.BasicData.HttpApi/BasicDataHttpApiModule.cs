using Microsoft.Extensions.DependencyInjection;
using Dedsi.BasicData.Core;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Dedsi.BasicData.HttpApi;

[DependsOn(
    typeof(BasicDataCoreModule),
    typeof(AbpAspNetCoreMvcModule)
)]
public class BasicDataHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BasicDataHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}