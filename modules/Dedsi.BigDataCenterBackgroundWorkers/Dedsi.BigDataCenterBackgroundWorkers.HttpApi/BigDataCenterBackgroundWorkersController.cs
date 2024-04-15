using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dedsi.BigDataCenterBackgroundWorkers.Core;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Dedsi.BigDataCenterBackgroundWorkers.HttpApi;

// [Authorize]
[Area(DedsiBigDataCenterBackgroundWorkersCoreOptions.ModuleName)]
[RemoteService(Name = DedsiBigDataCenterBackgroundWorkersCoreOptions.RemoteServiceName)]
[Route("api/BigDataCenterBackgroundWorkers/[controller]/[action]")]
public abstract class BigDataCenterBackgroundWorkersController : AbpControllerBase
{

}