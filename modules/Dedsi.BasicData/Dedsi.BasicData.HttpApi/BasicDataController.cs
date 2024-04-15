using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dedsi.BasicData.Core;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Dedsi.BasicData.HttpApi;

// [Authorize]
[Area(DedsiBasicDataCoreOptions.ModuleName)]
[RemoteService(Name = DedsiBasicDataCoreOptions.RemoteServiceName)]
[Route("api/BasicData/[controller]/[action]")]
public abstract class BasicDataController : AbpControllerBase
{

}