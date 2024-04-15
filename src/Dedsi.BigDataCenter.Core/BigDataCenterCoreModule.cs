using Volo.Abp.Application;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Dedsi.BigDataCenter.Core;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(AbpDddDomainModule)
)]
public class BigDataCenterCoreModule : AbpModule
{
    
}