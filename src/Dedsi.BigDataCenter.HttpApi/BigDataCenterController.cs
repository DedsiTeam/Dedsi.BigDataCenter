using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dedsi.BigDataCenter.Core;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Dedsi.BigDataCenter.HttpApi;

// [Authorize]
[Area(DedsiBigDataCenterCoreOptions.ModuleName)]
[RemoteService(Name = DedsiBigDataCenterCoreOptions.RemoteServiceName)]
[Route("api/BigDataCenter/[controller]/[action]")]
public abstract class BigDataCenterController : AbpControllerBase
{

}