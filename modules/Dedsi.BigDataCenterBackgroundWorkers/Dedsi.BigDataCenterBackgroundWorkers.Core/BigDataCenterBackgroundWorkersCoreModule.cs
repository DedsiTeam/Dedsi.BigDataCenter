using Volo.Abp.Application;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Dedsi.BigDataCenterBackgroundWorkers.Core;

[DependsOn(
    typeof(AbpDddApplicationModule),
    typeof(AbpDddDomainModule)
)]
public class BigDataCenterBackgroundWorkersCoreModule : AbpModule
{
    
}