using Volo.Abp.Application;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Dedsi.BasicData.Core;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(AbpDddDomainModule)
)]
public class BasicDataCoreModule : AbpModule
{
    
}